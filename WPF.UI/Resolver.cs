using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WPF.UI
{
    public class Resolver
    {
        private static Type requireAttr = typeof(RequireAttribute);
        private static Type extensionAttr = typeof(ExtensionAttribute);
        private static Type uiTagAttr = typeof(UITagAttribute);


        Dictionary<Type, TypeMeta> typeMetaMap;
        Dictionary<Type, ViewMeta> viewMetaMap;

        Dictionary<Type, Type> dependencyResolveMap;
        Dictionary<Type, Type> viewResolveMap;
        

        public Resolver()
        {
            initialize();
            RegisterDefaultService();
        }

        private void initialize()
        {
            typeMetaMap = new Dictionary<Type, TypeMeta>();
            viewMetaMap = new Dictionary<Type, ViewMeta>();

            dependencyResolveMap = new Dictionary<Type, Type>();
            viewResolveMap = new Dictionary<Type, Type>();
        }

        private void RegisterDefaultService()
        {
            RegisterUIService<ConfigService, Grid>();
        }

        public void RegisterDependency<TAbstract,TImpl>()
        {
            var targetType =  typeof(TAbstract);
            var implementType = typeof(TImpl);

            dependencyResolveMap.Add(targetType, implementType);
        }


        
        private TypeMeta recusiveAnalysisDependency(Type type)
        {
            var result = new TypeMeta();
            result.Type = type;
            result.IsAbstract = type.IsAbstract;
            var defaultCtor = GetDefaultCtor(type);
            if (defaultCtor == null)
            {
                throw new ResolveAnalysisExcpetion("can't find default constructor on [" + type.FullName + "; " + type.Assembly.FullName + "]");
            }
            result.DefaultConstructorInfo = defaultCtor;
            //prepare to collect dependenceis
            var propMetas = new List<PropertyMeta>();
            result.RequirePropertyMetas = propMetas;

            //create properties
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            
            foreach (var prop in properties)
            {
                var propMeta = new PropertyMeta();
                propMeta.PropertyType = PropertyType.Property;
                propMeta.PropertyInfo = prop;
                propMeta.TypeMeta = recusiveAnalysisDependency(prop.PropertyType);

                propMetas.Add(propMeta);
            }

            //create fields
            var fields = type.GetFields(BindingFlags.Instance);
            foreach (var field in fields)
            {
                var fieldMeta = new PropertyMeta();
                fieldMeta.PropertyType = PropertyType.Field;
                fieldMeta.FieldInfo = field;
                fieldMeta.TypeMeta = recusiveAnalysisDependency(field.FieldType);

                propMetas.Add(fieldMeta);
            }

            return result;
        }


        private ConstructorInfo GetDefaultCtor(Type type)
        {
            return type.GetConstructor(new Type[0]);
        }


        [Obsolete]
        public void RegisterDependency<TAbstract>(Func<TAbstract> factoryMethod)
        {
            
        }

        /// <summary>
        /// Warning: this method has a problem, if we have recursive requirement, then the ctor will recursive call and generate problems
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ResolveDependency<T>()
        {
            var requireType = typeof(T);
            return (T)ResolveDependency(requireType);
        }

        /// <summary>
        /// TODO: Add when the require dependency is not register but has a default ctor and is not abstract
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object ResolveDependency(Type type)
        {
            if (!dependencyResolveMap.ContainsKey(type))
            {
                throw new ResovleNotRegisterException(string.Format("{0} has not been registered", type.FullName));
            }

            var implType = dependencyResolveMap[type];

            if (!typeMetaMap.ContainsKey(implType))
            {
                typeMetaMap.Add(implType, recusiveAnalysisDependency(implType));
            }

            var implTypeMeta = typeMetaMap[implType];
            return RecursiveResolveDependency(implTypeMeta);   
        }

        /// <summary>
        /// this recursive maybe not good.(Combine it with resolve dependency)
        /// The TypeMeta's TypeMeta property maybe can change to Type 
        /// TODO: support singleton
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        private object RecursiveResolveDependency(TypeMeta targetType)
        {
            object newObj = null;

            if (!targetType.IsAbstract)
            {
                newObj = targetType.DefaultConstructorInfo.Invoke(null);
                foreach (var propMeta in targetType.RequirePropertyMetas)
                {
                    //think which method shall we use?
                    var subObj = ResolveDependency(propMeta.TypeMeta.Type);
                    if (propMeta.PropertyType == PropertyType.Property)
                    {
                        propMeta.PropertyInfo.GetSetMethod(true).Invoke(newObj, new object[] { subObj });
                    }
                    else
                    {
                        propMeta.FieldInfo.SetValue(newObj,subObj);
                    }
                }
            }
            else
            {
                newObj = ResolveDependency(targetType.Type);
            }

            return newObj;
        }

        public void RegisterUIService<TUIService, TView>()
            where TUIService:IUIService
        {

        }

        private IService RecursiveResolveService(Type serviceType, out UIElement view)
        {
            throw new NotImplementedException();
        }

        


        public Window ResolveWindow<TService>()
            where TService:IUIService
        {
            throw new NotSupportedException();
        }

        public UserControl ResolveUserControl<TService>()
        {
            throw new NotSupportedException();
        }

        public Control ResolveControl<TService>()
        {
            throw new NotSupportedException();
        }
    }
}

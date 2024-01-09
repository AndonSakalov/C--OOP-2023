using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fields)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(classToInvestigate);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {classToInvestigate}");

            foreach (var field in classFields.Where(c => fields.Contains(c.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue}");
            }

            return sb.ToString().TrimEnd();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            FieldInfo[] classFields = classType.GetFields();
            PropertyInfo[] classProperties = classType.GetProperties();

            foreach (var field in classFields.Where(f => !f.IsPrivate))
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var prop in classProperties)
            {
                if (prop.SetMethod.IsPrivate)
                {
                    sb.AppendLine($"{prop.Name} must be public!");
                }
                if (prop.GetMethod.IsPublic)
                {
                    sb.AppendLine($"{prop.Name} must be private!");
                }
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            Object classObj = Activator.CreateInstance(classType, new object[] { });

            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var privateMethod in privateMethods)
            {
                sb.AppendLine(privateMethod.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            Object classObj = Activator.CreateInstance(classType, new object[] { });

            MethodInfo[] allMethods = classType.GetMethods((BindingFlags)60);

            foreach (var getter in allMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }
            foreach (var setter in allMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{setter.Name} will set field of {setter.ReturnType}");
            }

            return sb.ToString().Trim();
        }
    }
}

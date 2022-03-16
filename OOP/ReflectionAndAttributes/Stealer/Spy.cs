using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string invesitagedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(invesitagedClass);
            FieldInfo[] fieldInfo = classType.GetFields((BindingFlags)60);
            StringBuilder sb = new StringBuilder();
            object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {invesitagedClass}");
            foreach (FieldInfo field in fieldInfo.Where(x=> requestedFields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Type type = Type.GetType(className);
            FieldInfo[] classFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (FieldInfo field in classFields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in publicMethods.Where(x => x.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo methodInfo in privateMethods.Where(x=>x.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{methodInfo.Name} have to be private!");
            }
            return stringBuilder.ToString().Trim();
        }
    }
}

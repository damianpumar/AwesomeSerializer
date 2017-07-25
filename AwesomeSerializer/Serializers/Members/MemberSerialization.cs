using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AwesomeSerializer.Serializers
{
    public class MemberSerialization<T> : IMemberSerialization
    {
        private readonly SerializeAction action;

        private readonly Expression<Func<T, dynamic>>[] properties;

        public MemberSerialization(SerializeAction action, params Expression<Func<T, dynamic>>[] properties)
        {
            this.action = action;

            this.properties = properties;
        }

        public SerializeAction Action
        {
            get
            {
                return this.action;
            }
        }

        public Type Type
        {
            get
            {
                return typeof(T);
            }
        }

        public IEnumerable<String> Properties
        {
            get
            {
                return this.properties.Select(p => this.GetPropertyName(p));
            }
        }

        private String GetPropertyName<Tprop>(Expression<Func<Tprop, dynamic>> expression)
        {
            var lambda = expression as LambdaExpression;

            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = lambda.Body as UnaryExpression;

                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = lambda.Body as MemberExpression;
            }

            if (memberExpression != null)
            {
                var propertyInfo = memberExpression.Member as PropertyInfo;

                return propertyInfo.Name;
            }

            return null;
        }
    }
}
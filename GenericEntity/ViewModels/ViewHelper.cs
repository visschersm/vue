using System;
using System.Linq.Expressions;

namespace ViewModels
{
    public static class ViewHelper<TEntity, TView>
    {
        public static Expression<Func<TEntity, TView>> SelectExpression
        {
            get; set;
        }
    }
}

using System;
using System.Linq.Expressions;

namespace ViewModels
{
    public static class ViewHelper<TEntity, TView>
    {
        public static Expression<Func<TEntity, TView>> SelectExpression
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private static Expression<Func<TEntity, TView>> _selectExpression;
    }
}

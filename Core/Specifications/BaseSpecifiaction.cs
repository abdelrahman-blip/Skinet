using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{ 
    public class BaseSpecifiaction<T> : Ispecification<T>
    {
      public BaseSpecifiaction()
      {
        
      }
      public BaseSpecifiaction(Expression<Func<T, bool>> criteria)
      {
        Criteria = criteria;
      }
        public Expression<Func<T, bool>> Criteria {get; }

        public List<Expression<Func<T, object>>> Includes {get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> Orderby  {get; set;} 

        public Expression<Func<T, object>> OrderbyDescending {get; set;}
        public int Skip  {get; set;} 

        public int Take {get; set;} 


        public bool IsPaginateEnabled {get; set;} 

        protected void AddInclude(Expression<Func<T, object>> includexpression)
      {
        Includes.Add(includexpression);
      }
      

      protected void AddOrderBy(Expression<Func<T, object>> Orderbyexpression)
      {
          Orderby = Orderbyexpression;
      }
      protected void AddOrderByDescening(Expression<Func<T, object>> OrderbyexpressionDescening)
      {
          OrderbyDescending = OrderbyexpressionDescening;
      }

      protected void ApplyPaging(int skip,int take)
      {
        Skip = skip;
        Take = take;
        IsPaginateEnabled = true;
      }
    }
}
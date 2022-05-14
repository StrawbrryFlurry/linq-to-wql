﻿using System.Linq.Expressions;
using System.Reflection;
using LinqToWql.Language;

namespace LinqToWql; 

public class WqlQueryProvider : IQueryProvider {
  private IQueryCompiler _compiler;
  private static readonly MethodInfo _createQueryMethod = GetGenericMethod(nameof(CreateQuery));
  private static readonly MethodInfo _executeMethod = GetGenericMethod(nameof(CreateQuery));
  
  public WqlQueryProvider(IQueryCompiler queryCompiler) {
    _compiler = queryCompiler;
  }
  
  public IQueryable CreateQuery(Expression expression) {
    var genericMakeQueryMethod = _createQueryMethod.MakeGenericMethod(expression.Type);
    return (IQueryable)genericMakeQueryMethod.Invoke(this, new object[] { expression })!;
  }

  public IQueryable<T> CreateQuery<T>(Expression expression) {
    return new WqlResource<T>(this, expression);
  }

  public object? Execute(Expression expression) {
    var genericExecuteMethod = _executeMethod.MakeGenericMethod(expression.Type);
    return genericExecuteMethod.Invoke(this, new object[] { expression })!;
  }

  public T Execute<T>(Expression expression) {
    return _compiler.Execute<T>(expression);
  }

  private static MethodInfo GetGenericMethod(string name) {
    return typeof(WqlQueryProvider)
      .GetMethods()
      .Single(m => m.Name == name && m.IsGenericMethod);
  }
}
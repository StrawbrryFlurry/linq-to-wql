﻿using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using LinqToWql.Model;

namespace LinqToWql;

public class WqlResource<T> : IQueryable<T> {
  public Type ElementType => typeof(T);
  public Expression Expression { get; }
  public IQueryProvider Provider { get; }

  public WqlResource(IQueryProvider provider, Expression? expression = null) {
    Provider = provider;
    Expression = expression ?? Expression.Constant(this);
  }

  public IEnumerator<T> GetEnumerator() {
    return Provider.Execute<IEnumerator<T>>(Expression);
  }

  IEnumerator IEnumerable.GetEnumerator() {
    return GetEnumerator();
  }

  /// <summary>
  ///   Returns the Wql resource name for the type.
  ///   The resource name is reflected by the `ResourceAttribute` on the generic type.
  /// </summary>
  /// <returns></returns>
  /// <exception cref="InvalidOperationException"></exception>
  public string GetResourceName() {
    var resourceType = typeof(T);
    var resourceAttribute = resourceType.GetCustomAttribute<ResourceAttribute>();

    if (resourceAttribute is null) {
      throw new InvalidOperationException($"Type {resourceType.Name} is not a valid WMI resource.");
    }

    return resourceAttribute.Name;
  }
}
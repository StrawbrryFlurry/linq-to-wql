﻿using System.Collections;
using LinqToWql.Data;
using Microsoft.ConfigurationManagement.ManagementProvider;

namespace LinqToWql.Test.Mocks.ResultObject;

public class StubResultObject : IResultObject {
  private readonly List<ResourceObject> _values;

  public object UserDataObject { get; set; }
  public ConnectionManagerBase ConnectionManager { get; }
  public bool TraceProperties { get; set; }
  public string DisplayString { get; }
  public string DisplayDescription { get; }
  public string HelpTopic { get; }
  public string ObjectClass { get; }
  public string OverridingObjectClass { get; }

  public IQueryPropertyItem this[string name] {
    get {
      I.Options.Properties.TryGetValue(name, out var value);
      return new StubQueryPropertyItem(value);
    }
    set => I.Options.Properties[name] = value;
  }

  public IResultObject Properties { get; set; }
  public int Count { get; }
  public string[] PropertyNames { get; }
  public Dictionary<string, string> PropertyList { get; }
  public int SecurityVerbs { get; }
  public bool AutoCommit { get; set; }
  public bool AutoRefresh { get; set; }
  public Dictionary<string, IResultObject> EmbeddedProperties { get; set; }
  public Dictionary<string, IResultObject> EmbeddedPropertyLists { get; set; }
  public Dictionary<string, IResultObject> RegMultiStringLists { get; set; }
  public List<IResultObject> GenericsArray { get; }
  public Guid UniqueIdentifier { get; }

  public StubResultObject(ResourceObject resourceObject) {
    _values = new List<ResourceObject> { resourceObject };
  }

  public StubResultObject(List<ResourceObject> resourceObjects) {
    _values = resourceObjects;
  }

  public int CompareTo(object? obj) {
    throw new NotImplementedException();
  }

  public void Dispose() {
  }

  public object Clone() {
    throw new NotImplementedException();
  }

  public IEnumerator GetEnumerator() {
    return _values.Select(x => new StubResultObject(x)).GetEnumerator();
  }

  public bool ContainsObjectClass(string type) {
    throw new NotImplementedException();
  }

  public string FormatQuery(string baseQuery, bool escapeForQueryUsage, bool normalizeValueForCondition) {
    throw new NotImplementedException();
  }

  public void Get(ReportProgress progressReport) {
    throw new NotImplementedException();
  }

  public void Get() {
    throw new NotImplementedException();
  }

  public void Put(ReportProgress progressReport) {
  }

  public void Put() {
  }

  public IResultObject ExecuteMethod(string methodName, Dictionary<string, object> methodParameters) {
    throw new NotImplementedException();
  }

  public void Delete(ReportProgress progressReport) {
  }

  public void Delete() {
  }

  public List<IResultObject> GetArrayItems(string propertyName) {
    throw new NotImplementedException(); 
  }

  public void SetArrayItems(string propertyName, List<IResultObject> value) {
    throw new NotImplementedException();
  }

  public IResultObject GetSingleItem(string propertyName) {
    throw new NotImplementedException();
  }

  public void SetSingleItem(string propertyName, IResultObject value) {
    throw new NotImplementedException();
  }

  public object GetQualifierValue(string qualifierName) {
    throw new NotImplementedException();
  }

  public void SetQualifierValue(string qualifierName, object qualifierValue) {
    throw new NotImplementedException();
  }

  private ResourceObject I => _values.First();
}
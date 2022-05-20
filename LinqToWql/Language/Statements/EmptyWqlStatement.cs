﻿using System.Linq.Expressions;
using LinqToWql.Language.Expressions;

namespace LinqToWql.Language.Statements;

public class EmptyWqlStatement : WqlStatement {
  public EmptyWqlStatement(Expression innerStatement) : base(innerStatement) {
  }
}
﻿
using System;

using iTin.Core.ComponentModel;
using iTin.Core.Hardware.Common.ComponentModel;

namespace iTin.Core.Hardware.Common;

/// <summary>
/// Specialization of <see cref="ResultBase{T}"/> interface.<br/>
/// Where <c>T</c> is <see cref="PropertyItemDictionary"/>.<br/>
/// Represents result after query operation.
/// </summary>
public class QueryPropertyDictionaryResult : ResultBase<PropertyItemDictionary>
{
    /// <summary>
    /// Returns a new <see cref="QueryPropertyDictionaryResult"/> with specified detailed error.
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="code">Error code</param>
    /// <returns>
    /// A new invalid <see cref="QueryPropertyDictionaryResult"/> with specified detailed error.
    /// </returns>
    public new static QueryPropertyDictionaryResult CreateErrorResult(string message, string code = "") => 
        CreateErrorResult([new ResultError { Code = code, Message = message }]);

    /// <summary>
    /// Returns a new <see cref="QueryPropertyDictionaryResult"/> with specified detailed error.
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="result">Result Result</param>
    /// <param name="code">Error code</param>
    /// <returns>
    /// A new invalid <see cref="QueryPropertyDictionaryResult"/> with specified detailed error.
    /// </returns>
    public new static QueryPropertyDictionaryResult CreateErrorResult(string message, PropertyItemDictionary result, string code = "") => 
        CreateErrorResult([new ResultError { Code = code, Message = message }], result);

    /// <summary>
    /// Returns a new <see cref="QueryPropertyDictionaryResult"/> with specified detailed errors' collection.
    /// </summary>
    /// <param name="errors">A errors collection</param>
    /// <returns>
    /// A new invalid <see cref="QueryPropertyDictionaryResult"/> with specified detailed errors' collection.
    /// </returns>
    public new static QueryPropertyDictionaryResult CreateErrorResult(IResultError[] errors) => new()
    {
        Result = default,
        Success = false,
        Errors = (IResultError[])errors.Clone()
    };

    /// <summary>
    /// Returns a new <see cref="QueryPropertyDictionaryResult"/> with specified detailed errors' collection.
    /// </summary>
    /// <param name="errors">A errors collection</param>
    /// <param name="result">Result Result</param>
    /// <returns>
    /// A new invalid <see cref="QueryPropertyDictionaryResult"/> with specified detailed errors' collection.
    /// </returns>
    public new static QueryPropertyDictionaryResult CreateErrorResult(IResultError[] errors, PropertyItemDictionary result) => new()
    {
        Result = result,
        Success = false,
        Errors = (IResultError[])errors.Clone()
    };

    /// <summary>
    /// Returns a new success result.
    /// </summary>
    /// <param name="result">Result Result</param>
    /// <returns>
    /// A new valid <see cref="QueryPropertyDictionaryResult"/>.
    /// </returns>
    public new static QueryPropertyDictionaryResult CreateSuccessResult(PropertyItemDictionary result) => new()
    {
        Result = result,
        Success = true,
        Errors = Array.Empty<IResultError>()
    };

    /// <summary>
    /// Creates a new <see cref="QueryPropertyDictionaryResult"/> instance from known exception.
    /// </summary>
    /// <param name="exception">Target exception.</param>
    /// <returns>
    /// A new <see cref="QueryPropertyDictionaryResult"/> instance for specified exception.
    /// </returns>
    public new static QueryPropertyDictionaryResult FromException(Exception exception) =>
        FromException(exception, default);

    /// <summary>
    /// Creates a new <see cref="QueryPropertyDictionaryResult"/> instance from known exception.
    /// </summary>
    /// <param name="exception">Target exception.</param>
    /// <param name="result">Result Result</param>
    /// <returns>
    /// A new <see cref="QueryPropertyDictionaryResult"/> instance for specified exception.
    /// </returns>
    public new static QueryPropertyDictionaryResult FromException(Exception exception, PropertyItemDictionary result) => new()
    {
        Result = result,
        Success = false,
        Errors = new ResultExceptionError { Exception = exception }.Yield()
    };
}

namespace Portfolio.Models;

/// <summary>
/// Represents a result type that encapsulates either a success value or an error value.
/// </summary>
/// <typeparam name="TValue">The type of the success value.</typeparam>
/// <typeparam name="TError">The type of the error value.</typeparam>
public readonly struct Result<TValue, TError>
{
    #region Private Fields
    
    /// <summary>
    /// The success value, if the result represents a success.
    /// </summary>
    private readonly TValue? _value;
    
    /// <summary>
    /// The error value, if the result represents an error.
    /// </summary>
    private readonly TError? _error;
    
    #endregion
    
    #region Public Properties
    
    /// <summary>
    /// Gets a value indicating whether the result represents an error.
    /// </summary>
    public bool IsError { get; }
    
    /// <summary>
    /// Gets a value indicating whether the result represents a success.
    /// </summary>
    public bool IsSuccess => !IsError;

    #endregion 
    
    #region Constructors/Operators
    
    /// <summary>
    /// Implicitly converts a success value to a <see cref="Result{TValue, TError}"/>.
    /// </summary>
    /// <param name="value">The success value.</param>
    public static implicit operator Result<TValue, TError>(TValue value) => new(value);
    
    /// <summary>
    /// Implicitly converts an error value to a <see cref="Result{TValue, TError}"/>.
    /// </summary>
    /// <param name="error">The error value.</param>
    public static implicit operator Result<TValue, TError>(TError error) => new(error);

    #endregion
    
    #region Public Methods
    
    /// <summary>
    /// Matches the result to one of two functions based on whether it is a success or an error.
    /// </summary>
    /// <typeparam name="TResult">The return type of the match functions.</typeparam>
    /// <param name="success">The function to invoke if the result is a success.</param>
    /// <param name="failure">The function to invoke if the result is an error.</param>
    /// <returns>The result of invoking the appropriate function.</returns>
    public TResult Match<TResult>(
        Func<TValue, TResult> success,
        Func<TError, TResult> failure
    ) => !IsError ? success(_value!) : failure(_error!);

    #endregion
    
    #region Private Methods
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue, TError}"/> struct as a success.
    /// </summary>
    /// <param name="value">The success value.</param>
    private Result(TValue value)
    {
        IsError = false;
        _value = value;
        _error = default;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue, TError}"/> struct as an error.
    /// </summary>
    /// <param name="error">The error value.</param>
    private Result(TError error)
    {
        IsError = true;
        _value = default;
        _error = error;
    }
    
    #endregion
}
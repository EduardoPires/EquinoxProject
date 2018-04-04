export class UserManagementResult {
    /// <summary>
    /// Flag indicating whether if the operation succeeded or not.
    /// </summary>
    /// <value>True if the operation succeeded, otherwise false.</value>
    public succeeded: boolean;
    /// <summary>
    /// Returns indicating a successful identity operation.
    /// </summary>
    public success: boolean;

    /// <summary>
    /// An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" />s containing an errors
    /// that occurred during the identity operation.
    /// </summary>
    /// <value>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" />s.</value>
    public errors: Array<UserManagementError>;
}

export class UserManagementError {
    /// <summary>Gets or sets the code for this error.</summary>
    /// <value>The code for this error.</value>
    public code: string;

    /// <summary>Gets or sets the description for this error.</summary>
    /// <value>The description for this error.</value>
    public description: string;
}

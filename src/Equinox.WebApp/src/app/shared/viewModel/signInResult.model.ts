export class SignInResult {

    /// <summary>
    /// Returns a flag indication whether the sign-in was successful.
    /// </summary>
    /// <value>True if the sign-in was successful, otherwise false.</value>
    public succeeded: boolean;

    /// <summary>
    /// Returns a flag indication whether the user attempting to sign-in is locked out.
    /// </summary>
    /// <value>True if the user attempting to sign-in is locked out, otherwise false.</value>
    public isLockedOut: boolean;

    /// <summary>
    /// Returns a flag indication whether the user attempting to sign-in is not allowed to sign-in.
    /// </summary>
    /// <value>True if the user attempting to sign-in is not allowed to sign-in, otherwise false.</value>
    public isNotAllowed: boolean;

    /// <summary>
    /// Returns a flag indication whether the user attempting to sign-in requires two factor authentication.
    /// </summary>
    /// <value>True if the user attempting to sign-in requires two factor authentication, otherwise false.</value>
    public requiresTwoFactor: boolean;
}

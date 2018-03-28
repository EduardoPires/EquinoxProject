import { SignInResult } from "./signInResult.model";
import { UserProfile } from "./userProfile.model";

export class LoginResult {
    public SignIn: SignInResult;
    public Profile: UserProfile;
}

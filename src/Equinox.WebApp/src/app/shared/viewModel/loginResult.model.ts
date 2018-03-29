import { SignInResult } from "./signInResult.model";
import { UserProfile } from "./userProfile.model";

export class LoginResult {
    public signInResult: SignInResult;
    public profile: UserProfile;
}

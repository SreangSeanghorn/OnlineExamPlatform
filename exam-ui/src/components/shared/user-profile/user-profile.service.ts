import {UserProfileModel} from './user-profile-model';
import {mockUserProfileData} from './mockdata/user-profile-mock.data';
import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'})
export class UserProfileService {
  private userProfile: UserProfileModel | null = null;

  constructor() {}


  setUserProfile(userProfile: UserProfileModel): void {
    this.userProfile = mockUserProfileData;
  }

  getUserProfile(): UserProfileModel | null {
    this.setUserProfile(mockUserProfileData);
    return this.userProfile;
  }
}

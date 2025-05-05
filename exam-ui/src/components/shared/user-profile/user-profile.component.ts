import {Component, inject, OnInit} from '@angular/core';
import {UserProfileService} from './user-profile.service';
import {UserProfileModel} from './user-profile-model';
import {MatButton} from '@angular/material/button';
import {MatMenu, MatMenuTrigger} from '@angular/material/menu';
import {MatIcon} from '@angular/material/icon';
import {NgStyle} from '@angular/common';

@Component({
  selector: 'app-user-profile',
  imports: [
    MatButton,
    MatMenuTrigger,
    MatMenu,
    MatIcon,
    NgStyle
  ],
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.scss'
})
export class UserProfileComponent implements OnInit{
  userProfileService: UserProfileService = inject(UserProfileService);
  userProfile : UserProfileModel | null = null;
  ngOnInit(): void {
    this.userProfile = this.userProfileService.getUserProfile();
    if (!this.userProfile) {
      console.error('User profile not found');
      // Handle the case when user profile is not found
    }
    console.log(this.userProfile);
  }


}

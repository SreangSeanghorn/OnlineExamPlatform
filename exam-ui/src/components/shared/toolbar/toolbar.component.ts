import { Component, Input } from '@angular/core';
import {MatToolbar} from '@angular/material/toolbar';
import {RouterLink, RouterLinkActive} from '@angular/router';
import {MatAnchor} from '@angular/material/button';
import {UserProfileComponent} from '../user-profile/user-profile.component';
import {NotificationComponent} from '../notification/notification.component';
import {UserSettingsComponent} from '../user-settings/user-settings.component';
import {NgForOf} from '@angular/common';

@Component({
    selector: 'app-toolbar',
    templateUrl: './toolbar.component.html',
    standalone: true,
  imports: [
    MatToolbar,
    RouterLink,
    RouterLinkActive,
    MatAnchor,
    UserProfileComponent,
    NotificationComponent,
    UserSettingsComponent,
    NgForOf,

  ],
    styleUrls: ['./toolbar.component.scss']

})
export class ToolbarComponent {
    @Input() tabs: { label: string; link: string }[] = [];
}

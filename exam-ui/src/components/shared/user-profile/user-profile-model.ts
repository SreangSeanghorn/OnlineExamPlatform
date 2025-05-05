export class UserProfileModel {
  id: string;
  name: string;
  username: string;
  gender: string;
  email: string;
  phone: string;
  profilePictureUrl: string;


  constructor(
    id: string,
    name: string,
    username: string,
    gender: string,
    email: string,
    phone: string,
    profilePictureUrl: string

  ) {
    this.id = id;
    this.name = name;
    this.gender = gender;
    this.username = username;
    this.email = email;
    this.phone = phone;
    this.profilePictureUrl = profilePictureUrl;
  }
}

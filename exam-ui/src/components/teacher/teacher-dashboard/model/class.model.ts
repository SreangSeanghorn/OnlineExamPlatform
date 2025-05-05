export class ClassModel{
  id: number;
  name: string;
  nickname: string;
  teacher: string;
  students: number;
  startDate: Date;
  endDate: Date;
  location: string;
  color?: string;
  image?: string;

  constructor(
    id: number,
    name: string,
    nickname: string,
    teacher: string,
    students: number,
    startDate: Date,
    endDate: Date,
    location: string,
    color?: string,
    image?: string
  ) {
    this.id = id;
    this.name = name;
    this.nickname = nickname;
    this.teacher = teacher;
    this.students = students;
    this.startDate = startDate;
    this.endDate = endDate;
    this.location = location;
    this.color = color;
    this.image = image;
  }
}

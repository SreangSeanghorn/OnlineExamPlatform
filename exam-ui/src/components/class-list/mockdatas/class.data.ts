import {ClassModel} from '../../teacher/teacher-dashboard/model/class.model';


export const classData : ClassModel[] = [
  new ClassModel(
    1,
    'Software Engineering',
    'SE101',
    'John Doe',
    30,
    new Date('2023-09-01'),
    new Date('2023-12-15'),
    'Room 101',
    '#006D5b',
    './assets/images/classroom.jpg',
  ),
  new ClassModel(
    2,
    'Data Structures',
    'DS201',
    'Jane Smith',
    25,
    new Date('2023-09-01'),
    new Date('2023-12-15'),
    'Room 102',
    '#FF5733',
    './assets/images/classroom2.jpg',
  ),
  new ClassModel(
    3,
    'Database Management',
    'DB301',
    'Alice Johnson',
    20,
    new Date('2023-09-01'),
    new Date('2023-12-15'),
    'Room 103',
    '#C70039'
  ),
  new ClassModel(
    4,
    'Web Development',
    'WD401',
    'Bob Brown',
    28,
    new Date('2023-09-01'),
    new Date('2023-12-15'),
    'Room 104',
    '#FFC300'
  ),
  new ClassModel(
    5,
    'Network Security',
    'NS501',
    'Charlie Green',
    22,
    new Date('2023-09-01'),
    new Date('2023-12-15'),
    'Room 105',
    '#581845'
  ),
  new ClassModel(
    6,
    'Machine Learning',
    'ML601',
    'David White',
    18,
    new Date('2023-09-01'),
    new Date('2023-12-15'),
    'Room 106',
    '#900C3F'
  ),
  new ClassModel(
    7,
    'Artificial Intelligence',
    'AI701',
    'Eva Black',
    26,
    new Date('2023-09-01'),
    new Date('2023-12-15'),
    'Room 107',
    '#FF5733'
  ),
];

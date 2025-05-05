import {Injectable} from '@angular/core';
import {Observable, of} from 'rxjs';
import {ClassModel} from '../model/class.model';
import {classData} from '../../../class-list/mockdatas/class.data';

@Injectable({
  providedIn: 'root'})
export class ClassService {
  constructor() {
  }

  getClasses(): Observable<ClassModel[]> {
    return of(classData);
  }
  getClassById(id: number): Observable<ClassModel | undefined> {
    const classItem = classData.find(item => item.id === id);
    return of(classItem);
  }


}

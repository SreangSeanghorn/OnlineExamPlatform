import {ScheduleModel} from '../model/schedule.model';
import {Injectable} from '@angular/core';
import {SCHEDULE} from '../mockdatas/schedule.data';
import { Observable } from 'rxjs';

@Injectable({providedIn:'root'})
export class ScheduleService{

  getSchedule(day:string) : Observable<ScheduleModel[]>{
    return new Observable<ScheduleModel[]>(observer => {
      const schedules = SCHEDULE.filter(schedule => schedule.day === day);
      observer.next(schedules);
      observer.complete();
    });
  }
  getScheduleById(id:number){
    return SCHEDULE.find(schedule=>schedule.id===id);
  }
  addSchedule(schedule:ScheduleModel){
    SCHEDULE.push(schedule);
  }
  updateSchedule(schedule:ScheduleModel){
    const index = SCHEDULE.findIndex(s=>s.id===schedule.id);
    SCHEDULE[index]=schedule;
  }
  deleteSchedule(id:number){
    const index = SCHEDULE.findIndex(s=>s.id===id);
    SCHEDULE.splice(index,1);
  }
}

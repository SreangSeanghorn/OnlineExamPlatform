using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Domain.Enums
{
    public enum NotificationType
    {
        UserRegistered ,
        ExamStarted,
        ExamEnded,
        ExamCanceled,
        ExamPostponed,
        ExamRescheduled,
        ExamUpdated,
        ExamDeleted,
        ExamCreated,
        ExamPublished,
        ResultPublished,
        SubmissionReceived,

        
    }
}
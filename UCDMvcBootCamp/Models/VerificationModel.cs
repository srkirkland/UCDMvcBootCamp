using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCDMvcBootCamp.Models
{
    public class VerificationModel
    {
        public int InitialConferenceCount { get; set; }
        public int ExpectedInitialConferenceCount { get { return 3; } }
        public bool VerifyInitialConferenceCount { get { return InitialConferenceCount == ExpectedInitialConferenceCount; } }

        public int NewConferenceCount { get; set; }
        public int ExpectedNewConferenceCount { get{ return 4;} }
        public bool VerifyNewConferenceCount { get{ return NewConferenceCount == ExpectedNewConferenceCount;} }

        public int RemovedConferenceCount { get; set; }
        public int ExpectedRemovedConferenceCount { get { return 3; } }
        public bool VerifyRemovedConferenceCount { get { return RemovedConferenceCount == ExpectedRemovedConferenceCount; } }

        public bool Verify()
        {
            return VerifyInitialConferenceCount && VerifyNewConferenceCount && VerifyRemovedConferenceCount;
        }
    }
}
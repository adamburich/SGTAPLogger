﻿//using SGTAPLogger.Src.Scorm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTAPLogger.Src
{
    public class MCQSubmits : MCQ
    {
        public MCQSubmits(String learner_name, String learner_id, String verb_string)
        :
            base(learner_name, learner_id, verb_string)
        { }
    }
}

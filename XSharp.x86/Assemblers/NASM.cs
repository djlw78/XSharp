﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XSharp.x86.Params;

namespace XSharp.x86.Assemblers {
    public class NASM : Assembler {
        protected readonly TextWriter mOut;
        protected readonly Map mMap;

        public NASM(TextWriter aOut) {
            mOut = aOut;

            mMap = new Map();
            AddPattern("{0}, 0x{1:X}", OpCode.Mov, typeof(RegXX), typeof(I32U));
        }

        protected void AddPattern(string aOutput, OpCode aOpCode, params Type[] aParamTypes) {
            Param.ActionDelegate xAction = (object[] aValues) => {
                // Can be done with a single call to .WriteLine but makes
                // debugging far more difficult.
                string xOut = string.Format(aOutput, aValues);
                mOut.WriteLine(xOut);
            };
            mMap.Add(xAction, aOpCode, aParamTypes);
        }

        public override void Emit(OpCode aOp, params object[] aParams) {
            mOut.Write(aOp + " ");
            mMap.Execute(aOp, aParams);
        }
    }
}

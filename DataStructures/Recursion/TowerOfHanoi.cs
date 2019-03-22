using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Recursion
{
    // https://www.educative.io/collection/page/10370001/760001/920002
    class TowerOfHanoi
    {
        // TODO: provide helpper functions and shape of output

        // You're given two helper functions.
        // 1) EdTestRunner.moveDisk(int fromPeg, int toPeg);
        //    It moves the top disk from the fromPeg to the toPeg.
        // 2) EdTestRunner.getSparePeg(int fromPeg, int toPeg);
        //    It returns the remaining peg.
        public static void solveHanoi(int disks, int fromPeg, int toPeg)
        {
            if (disks == 0)
            {
                return;
            }

            if (disks == 1)
            {
                //EdTestRunner.moveDisk(fromPeg, toPeg);
                return;
            }

            if (disks == 2)
            {
                int sparePeg = //EdTestRunner.getSparePeg(fromPeg, toPeg);
                //EdTestRunner.moveDisk(fromPeg, sparePeg);
                //EdTestRunner.moveDisk(fromPeg, toPeg);
                //EdTestRunner.moveDisk(sparePeg, toPeg);
                return;
            }

            //int spare = EdTestRunner.getSparePeg(fromPeg, toPeg);
            solveHanoi(disks - 1, fromPeg, spare);
            //EdTestRunner.moveDisk(fromPeg, toPeg);
            solveHanoi(disks - 1, spare, toPeg);
        }
    }
}

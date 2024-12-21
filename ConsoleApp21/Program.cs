using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    // bfs Binary Trees
    //איך נראה האלגוריתם?
    public void BFS(TreeNode root)
    {
        if (root == null) return;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root); // הוספת השורש לתור

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue(); // הוצאת הצומת הראשון בתור
                                                // עיבוד הצומת (למשל הדפסת הערך שלו)
            if (current.Left != null) queue.Enqueue(current.Left); // הוספת הילד השמאלי
            if (current.Right != null) queue.Enqueue(current.Right); // הוספת הילד הימני
        }
    }










    //חיפוש בעץ בינארי וסכום כול שלב ב BFS
    public class TreeNode
    {
        // מחלקה שמייצגת צומת בעץ בינארי
        public int Val; // ערך הצומת
        public TreeNode Left; // מצביע לצומת השמאלי
        public TreeNode Right; // מצביע לצומת הימני

        // בנאי לצומת בעץ
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            Val = val;
            Left = left;
            Right = right;
        }
    }

    public class Solution
    {
        // פונקציה לחישוב סכום הצמתים בכל רמה בעץ
        public IList<int> LevelOrderSum(TreeNode root)
        {
            // רשימה לאחסון סכומי הצמתים בכל רמה
            var result = new List<int>();

            // אם העץ ריק, נחזיר רשימה ריקה
            if (root == null) return result;

            // תור (Queue) לעיבוד הצמתים ברוחב (BFS)
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root); // מתחילים מהשורש

            // חיפוש ברוחב (BFS)
            while (queue.Count > 0)
            {
                // מספר הצמתים ברמה הנוכחית
                int levelSize = queue.Count;
                int levelSum = 0; // משתנה לאחסון סכום הצמתים ברמה הנוכחית

                // עיבוד כל הצמתים ברמה הנוכחית
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue(); // שולפים את הצומת הנוכחי מהתור
                    levelSum += currentNode.Val; // מוסיפים את ערך הצומת לסכום

                    // אם יש צומת שמאלי, מוסיפים אותו לתור
                    if (currentNode.Left != null)
                        queue.Enqueue(currentNode.Left);
                    // אם יש צומת ימני, מוסיפים אותו לתור
                    if (currentNode.Right != null)
                        queue.Enqueue(currentNode.Right);
                }

                // מוסיפים את הסכום של הרמה הנוכחית לרשימה
                result.Add(levelSum);
            }

            // מחזירים את רשימת הסכומים של כל הרמות
            return result;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    //מצאית כול הצמתים הימנים והחזרתם ברשימה



    public class Solution1
    {
        public IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();

            if (root == null) return result;

            // תור לעיבוד הצמתים ברוחב
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;

                // מעבדים כל רמה
                TreeNode rightmostNode = null;

                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();

                    // כל פעם שנפגשים בצומת, אנו מעדכנים את הצומת הימני ביותר
                    rightmostNode = currentNode;

                    // אם יש לו ילדים, מכניסים אותם לתור
                    if (currentNode.Left != null)
                        queue.Enqueue(currentNode.Left);
                    if (currentNode.Right != null)
                        queue.Enqueue(currentNode.Right);
                }

                // הוספת הצומת הימני ביותר של הרמה לרשימה
                result.Add(rightmostNode.Val);
            }

            return result;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    //הכנסת הצמתים זיג זאג לתוך התור



    public class Solution2
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();

            if (root == null) return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            // משתנה שמציין אם עלינו לעבור ברמה מימין לשמאל או משמאל לימין
            bool leftToRight = true;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                var level = new List<int>();

                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();

                    // אם עלינו לעבור משמאל לימין, נכניס את הערכים כמו שהם
                    // אם עלינו לעבור מימין לשמאל, נכניס את הערכים בסדר הפוך
                    if (leftToRight)
                        level.Add(currentNode.Val);
                    else
                        level.Insert(0, currentNode.Val); // insert at the beginning

                    if (currentNode.Left != null)
                        queue.Enqueue(currentNode.Left);
                    if (currentNode.Right != null)
                        queue.Enqueue(currentNode.Right);
                }

                // הוספת הרמה הנוכחית לרשימה
                result.Add(level);

                // הפיכת כיוון ה-BFS לרמה הבאה
                leftToRight = !leftToRight;
            }

            return result;
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    //חישוב המרחק הכי גדול בין צומת הכי שמלית לצומת הכי ימנית 
    public class Solution3
    {
        // הפונקציה מקבלת את שורש העץ ומחזירה את הרוחב המרבי של העץ
        public int MaxWidthOfBinaryTree(TreeNode root)
        {
            // אם השורש הוא null, אין עץ ולכן הרוחב המרבי הוא 0
            if (root == null) return 0;

            // יצירת תור (Queue) על מנת לבצע חיפוש ברוחב (BFS)
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root); // מוסיפים את השורש לתור

            // משתנה שיעקוב אחרי הרוחב המרבי של העץ
            int maxWidth = 0;

            // חיפוש ברוחב: כל פעם אנחנו מעבירים את כל הצמתים ברמה הנוכחית
            while (queue.Count > 0)
            {
                // מספר הצמתים ברמה הנוכחית (הגודל של התור)
                int levelSize = queue.Count;

                // משתנים שיעקבו אחרי המיקום של הצומת הראשון והאחרון ברמה
                int firstIndex = 0;
                int lastIndex = 0;

                // עיבוד כל הצמתים ברמה הנוכחית
                for (int i = 0; i < levelSize; i++)
                {
                    // הוצאת הצומת הראשון בתור
                    var node = queue.Dequeue();

                    // עדכון firstIndex ו-lastIndex עבור הרמה הנוכחית
                    if (i == 0) firstIndex = i; // הצומת הראשון ברמה
                    if (i == levelSize - 1) lastIndex = i; // הצומת האחרון ברמה

                    // אם לצומת יש צומת שמאלי, נוסיף אותו לתור
                    if (node.Left != null) queue.Enqueue(node.Left);

                    // אם לצומת יש צומת ימני, נוסיף אותו לתור
                    if (node.Right != null) queue.Enqueue(node.Right);
                }

                // חישוב רוחב הרמה הנוכחית: ההפרש בין lastIndex ל-firstIndex + 1
                maxWidth = Math.Max(maxWidth, lastIndex - firstIndex + 1);
            }

            // החזרת הרוחב המרבי שנמצא
            return maxWidth;
        }
    }






    internal class Program
    {
        static void Main(string[] args)
        {

            //חיפוש בעץ בינארי וסכום כול שלב ב BFS
            // יצירת עץ בינארי לדוגמה
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(5);
            root.Left.Left = new TreeNode(3);
            root.Right.Right = new TreeNode(4);

            // יצירת אובייקט של הפתרון
            Solution solution = new Solution();

            // קריאה לפונקציה כדי לחשב את סכום הצמתים בכל רמה
            IList<int> result = solution.LevelOrderSum(root);

            // הדפסת התוצאה
            Console.WriteLine("סכום הצמתים בכל רמה:");
            foreach (var sum in result)
            {
                Console.WriteLine(sum);
            }


            /////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////
            //מצאית כול הצמתים הימנים והחזרתם ברשימה
            // יצירת עץ לדוגמה
            TreeNode root1 = new TreeNode(1);
            root1.Left = new TreeNode(3);
            root1.Right = new TreeNode(4);
            root1.Left.Left = new TreeNode(2);
            root1.Right.Left = new TreeNode(7);
            root1.Right.Right = new TreeNode(8);

            // יצירת אובייקט של Solution
            Solution1 solution1 = new Solution1();

            // קריאה לפונקציה כדי למצוא את הצומת הימני ביותר בכל רמה
            var result1 = solution1.RightSideView(root1);

            // הדפסת התוצאה
            Console.WriteLine("צמתים ימניים בכל רמה: ");
            foreach (var val in result1)
            {
                Console.WriteLine(val);
            }
            /////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////
            //הכנסת הצמתים זיג זאג לתוך התור
            TreeNode root2 = new TreeNode(1);
            root2.Left = new TreeNode(3);
            root2.Right = new TreeNode(4);
            root2.Left.Left = new TreeNode(2);
            root2.Right.Left = new TreeNode(7);
            root2.Right.Right = new TreeNode(8);

            // יצירת אובייקט של Solution
            Solution2 solution2 = new Solution2();

            // קריאה לפונקציה כדי למצוא את הסדר בזיגזג
            var result2 = solution2.ZigzagLevelOrder(root2);

            // הדפסת התוצאה
            Console.WriteLine("תוצאות בזיגזג:");
            foreach (var level in result2)
            {
                Console.WriteLine($"[{string.Join(", ", level)}]");
            }


            /////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////
            //חישוב המרחק הכי גדול בין צומת הכי שמלית לצומת הכי ימנית 
            // יצירת עץ לדוגמה
            TreeNode root3 = new TreeNode(4);
            root3.Left = new TreeNode(2);
            root3.Right = new TreeNode(7);
            root3.Left.Left = new TreeNode(1);
            root3.Right.Left = new TreeNode(6);
            root3.Right.Right = new TreeNode(9);

            // יצירת אובייקט של Solution
            Solution3 solution3 = new Solution3();

            // קריאה לפונקציה כדי למצוא את הרוחב המרבי
            int maxWidth = solution3.MaxWidthOfBinaryTree(root3);

            // הדפסת התוצאה
            Console.WriteLine($"הרוחב המרבי של העץ הוא: {maxWidth}");

        }
    }
}

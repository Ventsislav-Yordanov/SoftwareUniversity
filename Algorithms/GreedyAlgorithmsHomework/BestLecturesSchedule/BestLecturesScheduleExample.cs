namespace BestLecturesSchedule
{
    using System;
    using System.Collections.Generic;

    public class BestLecturesScheduleExample
    {
        public static void Main()
        {
            int lecturesCount = int.Parse(Console.ReadLine().Split(':')[1]);
            var lectures = new Lecture[lecturesCount];
            for (int i = 0; i < lecturesCount; i++)
            {
                var lectureInfo = Console.ReadLine().Split(new char[] { ':', '-' });
                string name = lectureInfo[0];
                int start = int.Parse(lectureInfo[1]);
                int end = int.Parse(lectureInfo[2]);
                var newLecture = new Lecture(name, start, end);
                lectures[i] = newLecture;
            }

            Array.Sort(lectures, (first, second) => first.End.CompareTo(second.End));
            var selectedLectures = new List<Lecture>();
            var lastSelectedLecture = lectures[0];
            selectedLectures.Add(lastSelectedLecture);
            int selectedLecturesCount = 1;
            foreach (var lecture in lectures)
            {
                if (lecture.Start >= lastSelectedLecture.End)
                {
                    selectedLectures.Add(lecture);
                    lastSelectedLecture = lecture;
                    selectedLecturesCount++;
                }
            }

            Console.WriteLine($"Lectures ({selectedLecturesCount}):");
            foreach (var selectedLecture in selectedLectures)
            {
                Console.WriteLine(selectedLecture);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace WeeklyScheduler
{
    public partial class MainWindow : Window
    {

        public class Section
        {
            public readonly int sectionNumber;
            public readonly int startTime;
            public readonly Boolean MoWeFr;

            public Section(int startTime, int sectionNumber, Boolean MoWeFr)
            {
                this.startTime = startTime;
                this.sectionNumber = sectionNumber;
                this.MoWeFr = MoWeFr;
            }

            public override bool Equals(object obj)
            {
                // If parameter is null return false.
                if (obj == null)
                {
                    return false;
                }

                // If parameter cannot be cast to Point return false.
                Section p = obj as Section;
                if ((System.Object)p == null)
                {
                    return false;
                }

                // Return true if the fields match:
                return sectionNumber == p.sectionNumber && startTime == p.startTime && MoWeFr == p.MoWeFr;
            }

            public override int GetHashCode()
            {
                return sectionNumber;
            }
        }

        public class Class
        {
            public readonly String courseNumber;
            public readonly ArrayList listOfSections;

            public Class(String courseNumber, ArrayList listOfSections)
            {
                this.courseNumber = courseNumber;
                this.listOfSections = ArrayList.ReadOnly(listOfSections);
            }

            public override bool Equals(object obj)
            {
                // If parameter is null return false.
                if (obj == null)
                {
                    return false;
                }

                // If parameter cannot be cast to Point return false.
                Class p = obj as Class;
                if ((System.Object)p == null)
                {
                    return false;
                }

                // Return true if the fields match:
                return courseNumber.Equals(p.courseNumber);
            }

            public override int GetHashCode()
            {
                return courseNumber.GetHashCode();
            }

        }

        //Member Variables
        public ArrayList listOfClasses;
        public List<KeyValuePair<Class, Section>>[,] schedule = new List<KeyValuePair<Class, Section>>[5, 25];

        //Constructor
        public void IntItData()
        {
            ArrayList classes = new ArrayList();

            //Populate classes/sections
            ArrayList sections = new ArrayList();

            sections.Add(new Section(9, 1, true));
            sections.Add(new Section(14, 2, true));
            sections.Add(new Section(8, 3, true));
            classes.Add(new Class("MATH 216", new ArrayList(sections)));
            sections.Clear();

            sections.Add(new Section(13, 1, true));
            sections.Add(new Section(14, 2, true));
            sections.Add(new Section(12, 3, false));
            classes.Add(new Class("PHYS 201", new ArrayList(sections)));
            sections.Clear();

            sections.Add(new Section(13, 1, false));
            sections.Add(new Section(14, 3, false));
            classes.Add(new Class("CptS 423", new ArrayList(sections)));
            sections.Clear();

            sections.Add(new Section(9, 1, true));
            sections.Add(new Section(13, 2, true));
            sections.Add(new Section(10, 3, false));
            classes.Add(new Class("MATH 172", new ArrayList(sections)));
            sections.Clear();

            sections.Add(new Section(10, 1, true));
            sections.Add(new Section(12, 2, true));
            sections.Add(new Section(11, 3, false));
            classes.Add(new Class("CptS 260", new ArrayList(sections)));
            sections.Clear();

            listOfClasses = ArrayList.ReadOnly(classes);


            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    schedule[j, i] = new List<KeyValuePair<Class, Section>>();
                }
            }
        }

        //Adds a given section of a given class to the digital schedule
        public void AddSection(Class cla, Section sect)
        {
            KeyValuePair<Class, Section> toInsert = new KeyValuePair<Class, Section>(cla, sect);
            if (sect.MoWeFr)
            {
                schedule[0, sect.startTime].Add(toInsert);
                schedule[2, sect.startTime].Add(toInsert);
                schedule[4, sect.startTime].Add(toInsert);
            }
            else
            {
                schedule[1, sect.startTime].Add(toInsert);
                schedule[3, sect.startTime].Add(toInsert);
            }
            UpdateSchedule();
        }

        //Removes a given section of a given class from the digital schedule
        public void RemoveSection(Class cla, Section sect)
        {
            KeyValuePair<Class, Section> toRemove = new KeyValuePair<Class, Section>(cla, sect);
            if (sect.MoWeFr)
            {
                schedule[0, sect.startTime].Remove(toRemove);
                schedule[2, sect.startTime].Remove(toRemove);
                schedule[4, sect.startTime].Remove(toRemove);
            }
            else
            {
                schedule[1, sect.startTime].Remove(toRemove);
                schedule[3, sect.startTime].Remove(toRemove);
            }
            UpdateSchedule();
        }

        public void RemoveClass(Class cla)
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < schedule[j, i].Count; k++)
                    {
                        if (schedule[j, i][k].Key.Equals(cla))
                        {
                            schedule[j, i].RemoveAt(k);
                            k--;
                        }
                    }

                }
            }
            UpdateSchedule();
        }

        //Called when ever the digital schedule has been updated in order to update the visual schedule.
        public void UpdateSchedule()
        {
            Boolean popedup = false;
            scheduleDataGrid.Items.Clear();
            //Rebuild the UI of the schedule as necessary to reflect what is in the data.

            //Go through each index that maps to a cell in the UI
            //If empty clear said cell
            //If occupied mark cell as green, fill with text, mark matching drop down box as green.
            //If over-occupied mark as red, fill with both texts?, mark matching drop down boxes as green, grey out 'finish'.
            for (int time = 7; time < 19; time++)
            {
                DaysOfWeek row = new DaysOfWeek();
                for (int day = 0; day < 5; day++)//Loop through each timeslot in the schedule.
                {
                    List<KeyValuePair<Class, Section>> timeSlot = schedule[day, time];
                    String daystring = "";
                    if (timeSlot.Count == 0)
                    {
                        daystring = "";
                    }

                    // One class at this time
                    else if (timeSlot.Count == 1)
                    {
                        daystring = schedule[day, time][0].Key.courseNumber + "\n" + schedule[day, time][0].Value.startTime + ":00-" + (schedule[day, time][0].Value.startTime + 1) + ":00 ";
                    }

                    // Overbooked
                    else if (timeSlot.Count > 1)
                    {
                        StringBuilder balh = new StringBuilder("");

                        foreach(KeyValuePair<Class,Section> cla in schedule[day, time])
                        {
                            balh.Append(cla.Key.courseNumber +"\n"+ schedule[day, time][0].Value.startTime + ":00-" + (schedule[day, time][0].Value.startTime + 1) + ":00 " + "\n");
                        }

                        daystring = balh.ToString();
                        if(!popedup)
                            MessageBox.Show("Some of your classes are conflicting!");
                        popedup = true;

                    }

                    switch (day)
                    {
                        case 0: row.monday = daystring; break;
                        case 1: row.tuesday = daystring; break;
                        case 2: row.wednesday = daystring; break;
                        case 3: row.thursday = daystring; break;
                        case 4: row.friday = daystring; break;
                    }
                }
                scheduleDataGrid.Items.Add(row);
            }
        }
    }
}
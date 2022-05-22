using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiffingAPITask.Models
{
    public class Diff
    {
        //init variables
        private int offset;
        private int length;
        private string diffResultType;

        List<DiffModel> myList = new List<DiffModel>();

        public Diff()
        {

        }

        //functions to get and set the offset and lengths

        public void setOffset(int offset)
        {
            this.offset = offset;
        }




        public int getOffset()
        {
            return offset;
        }


        public void setdiffResultType(string result)
        {
            this.diffResultType = result;
        }

        public string getdiffResultType()
        {
            return this.diffResultType;
        }

        public void setlength(int length)
        {
            this.length = length;
        }


        public int setLength()
        {
            return length;
        }



        //function to check if pair is equal

        public bool equals(object obj)
        {

            return false;
        }

        public string rtnVal()
        {
            return JsonConvert.SerializeObject(this.diffResultType + myList);
        }


        public void add(string value,string Position)
        {
            DiffModel diff = new DiffModel();
            diff.data = value;
            diff.length = value.Length;
            diff.position = Position;



            if (Position == "left")
            {
                //LEFT SIDE

                //check if right has any data

                bool hasRight = myList.Any(item => item.position == "right");


                if (hasRight)
                {
                    // there is data in the right
                    //check length and type
                    bool sameLegnth = myList.Where(item => item.position == "right").Any(item => item.length == value.Length);
                    bool sameData = myList.Where(item => item.position == "right").Any(item => item.data == value);
                    if (sameLegnth && sameData)
                    {
                        setdiffResultType("Equals");
                    }
                    else if (sameLegnth && !sameData)
                    {
                        setdiffResultType("ContentDoNotMatch");
                    }
                    else
                    {
                        setdiffResultType("SizeDoNotMatch");
                    }



                }
                else
                {
                    // no data in the right
                    setdiffResultType("");
                }



                //finally add the data to the left side
                if (myList.Any(item => item.position == "left"))
                {
                    myList.RemoveAt(0);
                    myList.Insert(0, diff);
                }

            }
            else
            {
                //RIGHT SIDE


                //check if left has any data

                bool hasLeft = myList.Any(item => item.position == "left");


                if (hasLeft)
                {
                    // there is data in the left
                    //check length and type
                    bool sameLegnth = myList.Where(item => item.position == "left").Any(item => item.length == value.Length);
                    bool sameData = myList.Where(item => item.position == "left").Any(item => item.data == value);
                    if (sameLegnth && sameData)
                    {
                        setdiffResultType("Equals");
                    }
                    else if (sameLegnth && !sameData)
                    {
                        setdiffResultType("ContentDoNotMatch");
                    }
                    else 
                    {
                        setdiffResultType("SizeDoNotMatch");
                    }

                   
                    
                }
                else
                {
                    // no data in the left
                    setdiffResultType("");
                }



                //finally add the data to the right side
                if (myList.Any(item => item.position == "right"))
                {
                    myList.RemoveAt(1);
                    myList.Insert(1,diff);
                }
                


            }


        }

    }
}
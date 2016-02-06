using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get { return this.grade; } 
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("grade", "Grade cannot be less than zero.");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get { return this.minGrade; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("minGrade", "Min Grade cannot be less than zero.");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get { return this.maxGrade; }
        private set
        {
            if (value <= minGrade)
            {
                throw new ArgumentOutOfRangeException("maxGrade", "Max Grade must be bigger than mix grade.");
            }

            this.maxGrade = value;
        }
    }


    public string Comments
    {
        get { return this.comments; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("comments", "The comments cannot be null or empty.");
            }

            this.comments = value;
        }
    }
}

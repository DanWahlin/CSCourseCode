//////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Objects;

namespace HRSkillsOnline
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void skillsTextBox_TextChanged(object sender, EventArgs e)
        {
            // Remove the existing data source binding.
            employeeGridView.DataSourceID = string.Empty;

            if (skillsTextBox.Text != string.Empty)
            {
                using (HRSkillsEntities context = new HRSkillsEntities())
                {
                    // Define a new binding source to hold our list of filtered employees.
                    List<Employee> filteredEmployees = new List<Employee>();

                    try
                    {
                        // Make a list of keywords to search for in 
                        // Skill entity name and description.
                        List<string> keywords = new List<string>();
                        int i = 0;
                        int j = 0;

                        while (i < skillsTextBox.Text.Length)
                        {
                            j = skillsTextBox.Text.IndexOf(" ", i);
                            if (-1 == j) j = skillsTextBox.Text.Length;
                            keywords.Add(
                                skillsTextBox.Text.Substring(i, j - i));

                            i = ++j;
                        }

                        foreach (string keyword in keywords)
                        {
                            // Create ObjectParameter from each keyword 
                            // and search properties of Skills.
                            ObjectParameter param = new ObjectParameter(
                                "p", "%" + keyword + "%");

                            // Query for skills that match the supplied string.
                            var skillsQuery =
                                context.Skills.Where("it.BriefDescription Like @p " +
                                "OR it.SkillName Like @p", param);

                            foreach (Skill skill in skillsQuery)
                            {
                                // Load the related employee for the skill.
                                if (!skill.EmployeeReference.IsLoaded)
                                {
                                    skill.EmployeeReference.Load();
                                }

                                // Build a BindingSource of Employees based on
                                // the skills returned by the query.
                                if (!filteredEmployees.Contains(skill.Employee))
                                {
                                    filteredEmployees.Add(skill.Employee);
                                }
                            }
                        }

                        // Bind the constructed list of employees to the binding source.
                        employeeGridView.DataSource = filteredEmployees;
                        employeeGridView.DataBind();
                    }
                    catch (Exception ex)
                    {
                        if (Request.IsLocal)
                        { Session["CurrentError"] = ex.Message; }
                        else
                        { Session["CurrentError"] = "Error processing page."; }
                    }
                }
            }
            else
            {
                // Reset the default binding if the text box is empty.
                employeeGridView.DataSourceID = "EmployeeDataSource";
                employeeGridView.SelectedIndex = -1;
            }
        }
        protected void employeeGridView_SelectedIndexChanged(object sender,
        EventArgs e)
        {
            // Reset the skills grid view when the employee changes.
            skillsGridView.SelectedIndex = -1; 
        }
    }
}
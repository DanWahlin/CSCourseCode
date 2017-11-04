//////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Mapping;
using System.Data.Objects;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace HRSkillsWinApp
{
    public partial class SkillsForm : Form
    {
        HRSkillsEntities context = new HRSkillsEntities();
        Employee currentEmployee;
        Skill selectedSkill;
        
        public SkillsForm()
        {
            InitializeComponent();

            // Register the SavingChanges event handler.
            context.SavingChanges += new EventHandler(context_SavingChanges);

            GetAllEmployees();
            dataGridViewEmployees.Focus();
        }

        private void GetAllEmployees()
        {
            try
            {
                // Bind the employees data source to the query results for all employees.
                employeesBindingSource.DataSource = context.Employees.OrderBy("it.LastName")
                    .Execute(MergeOption.AppendOnly);

                // Get the current Employee.
                currentEmployee = (Employee)employeesBindingSource.Current;

                if (currentEmployee != null)
                {
                    // Load the skills for the current employee.
                    if (!currentEmployee.Skills.IsLoaded)
                    {
                        currentEmployee.Skills.Load();
                    }

                    // Raise the employee selected event.
                    dataGridViewEmployees_CurrentCellChanged(null, null);
                }
            }
            catch (EntityException ex)
            {
                MessageBox.Show(string.Format("The following error has occured: {0}\n"
                    + "Ensure that the data source has been set correctly in the "
                    + "configuration file.", ex.Message), "An error has occured.");

                // Close the application.
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridViewEmployees_CurrentCellChanged(object sender, EventArgs e)
        {
            // Update the current employee to currently selected one.
            currentEmployee = (Employee)employeesBindingSource.Current;

            if (currentEmployee != null)
            {

                // Load the skills for the current employee.
                if (!currentEmployee.Skills.IsLoaded)
                {
                    currentEmployee.Skills.Load(MergeOption.OverwriteChanges);
                }

                // Make sure we call the handler to simulate selection of a skill.
                dataGridViewSkills_CurrentCellChanged(null, null);
            }
        }

        private void dataGridViewSkills_CurrentCellChanged(object sender, EventArgs e)
        {
            skillsRefsTextBox.Clear();

            // Update the selected skill.
            selectedSkill = (Skill)skillsBindingSource.Current;

            if (selectedSkill != null)
            {

                // Write the name of the skill and brief 
                // description to richtext box.
                skillsRefsTextBox.Text += string.Format("Skill Name: {0}\n{1}\n\nSkill Information:\n",
                    selectedSkill.SkillName, selectedSkill.BriefDescription);

                // Make sure we don't try to load related objects when
                // the skill is still in the Added state.
                if (selectedSkill.EntityState != EntityState.Added)
                {

                    // Load the related SkillInfo object.
                    if (!selectedSkill.SkillInfoes.IsLoaded)
                    {
                        selectedSkill.SkillInfoes.Load(MergeOption.OverwriteChanges);
                    }
                    foreach (SkillInfo skillInfo in selectedSkill.SkillInfoes)
                    {
                        skillsRefsTextBox.Text += String.Format("\t{0}\n",
                            skillInfo.URL);
                    }

                    // Write the heading for the references.
                    skillsRefsTextBox.Text += "\n\nReferences:\n";

                    // Load References of Employee using 
                    // Reference_Employee association.
                    if (!currentEmployee.References.IsLoaded)
                    {
                        currentEmployee.References.Load();
                    }

                    foreach (Reference reference in currentEmployee.References)
                    {
                        // Write reference LastName and Position to rich text box.
                        skillsRefsTextBox.Text += string.Format("\t{0} {1} Position: {2} Email: {3}\n",
                            reference.FirstName, reference.LastName,
                            reference.Position, reference.Email);
                    }

                    skillsRefsTextBox.Refresh();
                }
            }
        }

        private void richTextBox1_LinkClicked(object sender, 
            LinkClickedEventArgs e)
        {  
            // Display the SkillInfo Url in Web browser.
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void buttonSkillSearch_Click(object sender, EventArgs e)
        {
            // Define a new binding source to hold our list of filtered employees.
            BindingSource filteredEmployees = new BindingSource(); 
            
            try
            {
                // Make a list of keywords to search for in 
                // Skill entity name and description.
                List<string> keywords = new List<string>();
                int i = 0;
                int j = 0;

                while (i < textBoxKeywords.Text.Length)
                {
                    j = textBoxKeywords.Text.IndexOf(" ", i);
                    if (-1 == j) j = textBoxKeywords.Text.Length;
                    keywords.Add(
                        textBoxKeywords.Text.Substring(i, j - i));

                    i = ++j;
                }

                foreach (string keyword in keywords)
                {
                    // Create ObjectParameter from each keyword 
                    // and search properties of Skills.
                    ObjectParameter param = new ObjectParameter(
                        "p", "%" + keyword + "%");

                    // Query for skills that match the supplied string.
                    ObjectQuery<Skill> skillsQuery =
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

                if (filteredEmployees.Count > 0)
                {
                    // Bind the constructed list of employees to the binding source.
                    employeesBindingSource.DataSource = filteredEmployees;
                    employeesBindingSource.MoveFirst();

                    // Refresh the employees grid for the current filtered employee.
                    dataGridViewEmployees_CurrentCellChanged(null, null);
                }
                else
                {
                    MessageBox.Show("The supplied query returned no matching employees.", 
                        "No Matching Skills");
                }
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(),
                    "Error Message");
            }

        }

        private void textBoxKeywords_PreviewKeyDown(object sender, 
            PreviewKeyDownEventArgs e)
        {
            // Provide Enter activation in Search text box.
            if(e.KeyCode.Equals(Keys.Return))
                buttonSkillSearch_Click(this, System.EventArgs.Empty );                
        }

        private void buttonSubmitEmployee_Click(object sender, 
            EventArgs e)
        {
            try
            {
                if (textBoxLastName.Text == string.Empty ||
                    textBoxFirstName.Text == string.Empty ||
                    textBoxEmployeeEmail.Text == string.Empty ||
                    textBoxEmployeeAlias.Text == string.Empty)
                {
                    MessageBox.Show("Make sure that all information is supplied for an employee.");
                    return;
                }

                if (!textBoxEmployeeEmail.Text.Contains('@'))
                {
                    MessageBox.Show("Make sure that a valid email address is supplied.");
                    return;
                }
                
                // Check for duplicates.
                ObjectParameter[] parameters = 
                {new ObjectParameter("p", textBoxFirstName.Text),
                    new ObjectParameter("q", textBoxLastName.Text) };

                ObjectQuery<Employee> dbEmplQuery =
                    context.Employees.Where("it.FirstName = @p && it.LastName =@q",
                    parameters);

                if (dbEmplQuery.Any())
                {
                    MessageBox.Show("This employee already exists.");
                    return;
                }

                // Create new Employee.
                Employee newEmployee = new Employee();
                newEmployee.LastName = textBoxLastName.Text;
                newEmployee.Alias = textBoxEmployeeAlias.Text;                    
                newEmployee.FirstName = textBoxFirstName.Text;
                newEmployee.Email = textBoxEmployeeEmail.Text;
                
                // Add the new employee.
                context.AddToEmployees(newEmployee);               
                
                // Save changes to the database.
                context.SaveChanges();

                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxEmployeeAlias.Clear();
                textBoxEmployeeEmail.Clear();                

                GetAllEmployees();

                employeesBindingSource.Position = 
                    employeesBindingSource.IndexOf(newEmployee);
 
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), 
                    "Error Message");
            }
        }

        private void buttonSubmitSkill_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentEmployee == null)
                {
                    MessageBox.Show("You must add or select an employee first.", "Error Message");
                    return;
                }

                // Create new Skills entity.
                Skill newSkill = new Skill();
                newSkill.SkillName = textBoxSkillShortName.Text;
                newSkill.BriefDescription =
                    textBoxSkillBriefDescription.Text;

                // Add the skill to the current employee.
                currentEmployee.Skills.Add(newSkill);

                // Save changes to the database.
                context.SaveChanges();

                // Call the employee handler to display the new skill in the grid.
                dataGridViewEmployees_CurrentCellChanged(null, null);

                textBoxSkillShortName.Clear();
                textBoxSkillBriefDescription.Clear();
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("The following error has occured: {0}", 
                    ex.Message), "Error Message");
            }
        }

        private void buttonSubmitSkillInfo_Click(object sender,
    EventArgs e)
        {
            try
            {
                if (selectedSkill == null)
                {
                    MessageBox.Show("Make sure that a skill is selected.");
                    return;
                }

                // Create new SkillInfo entity.
                SkillInfo newSkillInfo = new SkillInfo();
                newSkillInfo.URL = textBoxUrlUncSkillInfo.Text;

                // Add SkillInfo to the selected skill.
                selectedSkill.SkillInfoes.Add(newSkillInfo);
                
                // Save the changes to the database.
                context.SaveChanges();

                // Call the handler to simulate the selection of a skill
                // to update the display.
                dataGridViewSkills_CurrentCellChanged(null, null);

                textBoxUrlUncSkillInfo.Clear();
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(),
                    "Error Message");
            }

        }

        private void buttonSubmitReference_Click(
    object sender, EventArgs e)
        {
            try
            {
                if (currentEmployee == null)
                {
                    MessageBox.Show("Make sure that an employee is selected.");
                    return;
                }
                if (textBoxRefFirstName.Text == string.Empty ||
                    textBoxRefLastName.Text == string.Empty ||
                    textBoxRefEmail.Text == string.Empty ||
                    textBoxRefPosition.Text == string.Empty)
                {
                    MessageBox.Show("Make sure that all information is supplied for a reference.");
                    return;
                }

                if (!textBoxRefEmail.Text.Contains('@'))
                {
                    MessageBox.Show("Make sure that a valid email address is supplied.");
                    return;
                }

                // Create new Reference and add it to the current employee
                // To define a new relationship.
                Reference newReference = new Reference();
                newReference.LastName = textBoxRefLastName.Text;
                newReference.Email = textBoxRefEmail.Text;           
                newReference.Alias =
                    textBoxRefEmail.Text.Remove(
                    textBoxRefEmail.Text.IndexOf('@'));
                newReference.FirstName = textBoxRefFirstName.Text;
                newReference.Position = textBoxRefPosition.Text;

                // Add the new reference to the current employee.
                currentEmployee.References.Add(newReference);

                // Save changes to the database.
                context.SaveChanges();

                // Call the handler to simulate the selection of a skill
                // to update the display.
                dataGridViewSkills_CurrentCellChanged(null, null);

                textBoxRefFirstName.Clear();
                textBoxRefLastName.Clear();
                textBoxRefEmail.Clear();
                textBoxRefPosition.Clear();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(),
                    "Error Message");
            }

        }

        private void context_SavingChanges(object sender, EventArgs e)
        {
            // Create new GUID's for all added entity objects.
            foreach (ObjectStateEntry entry in
                context.ObjectStateManager.GetObjectStateEntries(EntityState.Added))
            {
                if (!entry.IsRelationship)
                {
                    if (entry.Entity.GetType() == typeof(Employee))
                    {
                        ((Employee)entry.Entity).EmployeeId = Guid.NewGuid();
                    }
                    else if (entry.Entity.GetType() == typeof(Skill))
                    {
                        ((Skill)entry.Entity).SkillId = Guid.NewGuid();
                    }
                    else if (entry.Entity.GetType() == typeof(SkillInfo))
                    {
                        ((SkillInfo)entry.Entity).SkillInfoId = Guid.NewGuid();
                    }
                    else if (entry.Entity.GetType() == typeof(Reference))
                    {
                        ((Reference)entry.Entity).ReferenceId = Guid.NewGuid();
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            context.Dispose();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.textBoxKeywords.Clear();
            GetAllEmployees();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

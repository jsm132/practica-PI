using ESproject.Schedule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ESproject.UI
{
    public partial class schedule : Form
    {
        Plan plan;
        public schedule()
        {
            InitializeComponent();
            this.Show();
            plan = new Plan();
        }

        private void schedule_Load(object sender, EventArgs e)
        {

        }

        private void cancelSchedule_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void createSchedule_Button_Click(object sender, EventArgs e)
        {
            plan.setScheduleName(planName_TextBox.Text);
            repeatedName_Label.Visible = false;
            bool ok = Schedule.Schedule.SaveOnJson(plan);
            if (ok == false)
            {
                repeatedName_Label.Visible = true;
            }
            else
            { 
                Schedule.Schedule.SendToServer();
                this.Close();
            }
        }

        private void enableButton() // en el caso de que todos los campos del formulario estén rellenados, se habilitará el botón de crear
        {
            if (planName_TextBox.Text != "" && weekSelect_comboBox.SelectedItem != null && daySelect_comboBox.SelectedItem != null && backupType_comboBox.SelectedItem != null && hour_comboBox.SelectedItem != null && minute_comboBox.SelectedItem != null)
            {
                addDay_Button.Enabled = true;
            }
            else
            {
                addDay_Button.Enabled = false;
            }

            if (scheduleShow_TextBox.Text.Equals(""))
            {
                createSchedule_Button.Enabled = false;
            }
            else
            {
                createSchedule_Button.Enabled = true;
            }

        }

        private void planName_TextBox_TextChanged_1(object sender, EventArgs e)
        {
            enableButton();
        }

        private void weekSelect_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableButton();
        }

        private void daySelect_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableButton();
        }

        private void backupType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableButton();
        }

        private void hour_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableButton();
        }

        private void minute_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableButton();
        }

        private void addDay_Button_Click(object sender, EventArgs e)
        {

            plan.addDay(weekSelect_comboBox.SelectedItem.ToString(), daySelect_comboBox.SelectedItem.ToString(), backupType_comboBox.SelectedItem.ToString(), hour_comboBox.SelectedItem.ToString(), minute_comboBox.SelectedItem.ToString());

            scheduleShow_TextBox.Text = "";

            foreach(Schedule.Day element in plan.days)
            {
                scheduleShow_TextBox.Text += element.week + " " + element.weekDay + " " + element.hour + ":" + element.minute + " " + element.backupType + "\r\n";
            }

            weekSelect_comboBox.ResetText();
            daySelect_comboBox.ResetText();
            backupType_comboBox.ResetText();
            hour_comboBox.ResetText();
            minute_comboBox.ResetText();

            weekSelect_comboBox.SelectedItem = null;
            daySelect_comboBox.SelectedItem = null;
            backupType_comboBox.SelectedItem = null;
            hour_comboBox.SelectedItem = null;
            minute_comboBox.SelectedItem = null;

            enableButton();
        }
    }
}

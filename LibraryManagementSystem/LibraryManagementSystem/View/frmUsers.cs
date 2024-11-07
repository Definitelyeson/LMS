using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.Model;
using System.IO;

namespace LibraryManagementSystem.View
{
    public partial class frmUsers : Form
    {
        private UsersViewModel usersViewModel; // Use UsersViewModel
        private int currentPage = 1;
        private int itemsPerPage = 9;

        public frmUsers()
        {
            InitializeComponent();

            usersViewModel = new UsersViewModel(); // Initialize UsersViewModel
            DisplayUsers(usersViewModel.UsersList, currentPage);
        }

        private void DisplayUsers(List<Users> usersList, int pageNumber)
        {
            tableLayoutPanel1.Controls.Clear();
            int startIndex = (pageNumber - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, usersList.Count);


            for (int i = startIndex; i < endIndex; i++)
            {
                var user = usersViewModel.UsersList[i]; // Get the user instead of book

                // Panel for each user
                System.Windows.Forms.Panel userPanel = new System.Windows.Forms.Panel
                {
                    Size = new Size(535, 230),
                    Margin = new Padding(30),
                    BackColor = Color.LightGreen,
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Picture for profile photo
                PictureBox profilePhoto = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(100, 120),
                    Location = new Point(10, 10),
                    BorderStyle = BorderStyle.None
                };

                if (!string.IsNullOrEmpty(user.PhotoPath) && File.Exists(user.PhotoPath))
                {
                    profilePhoto.Image = System.Drawing.Image.FromFile(user.PhotoPath);
                }
                else
                {
                    profilePhoto.Image = Properties.Resources.default_image; // Placeholder
                }

                // Label for Name
                System.Windows.Forms.Label lblName = new System.Windows.Forms.Label
                {
                    Text = $"Name: {user.Name}", // Show user name
                    Location = new Point(120, 10),
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    AutoSize = true
                };

                // Label for Contact No.
                System.Windows.Forms.Label lblContact = new System.Windows.Forms.Label
                {
                    Text = $"Contact: {user.ContactNo}", // Show contact number
                    Location = new Point(120, 43),
                    Font = new Font("Segoe UI", 9),
                    AutoSize = true
                };

                // Label for Contact No.
                System.Windows.Forms.Label lblAddress = new System.Windows.Forms.Label
                {
                    Text = $"Address: {user.Address}", // Show contact number
                    Location = new Point(120, 58),
                    Font = new Font("Segoe UI", 9),
                    AutoSize = true
                };

                // Label for Email
                System.Windows.Forms.Label lblEmail = new System.Windows.Forms.Label
                {
                    Text = $"Email: {user.EmailAddress}", // Show email address
                    Location = new Point(120, 73),
                    Font = new Font("Segoe UI", 9),
                    AutoSize = true
                };

                // Label for other details (Birth Date, Position, etc.)
                System.Windows.Forms.Label lblOtherDetails = new System.Windows.Forms.Label
                {
                    Text = $"Birth Date: {(user.BirthDate.HasValue ? user.BirthDate.Value.ToShortDateString() : "N/A")}",
                    Location = new Point(120, 28),
                    Font = new Font("Segoe UI", 9),
                    AutoSize = true
                };

                // Label for other details (Birth Date, Position, etc.)
                System.Windows.Forms.Label lblPosition = new System.Windows.Forms.Label
                {
                    Text = $"Position: {user.Position}",
                    Location = new Point(120, 89),
                    Font = new Font("Segoe UI", 9),
                    AutoSize = true
                };

                // Label for other details (Birth Date, Position, etc.)
                System.Windows.Forms.Label lblUsername = new System.Windows.Forms.Label
                {
                    Text = $"Username: {user.Username}",
                    Location = new Point(120, 103),
                    Font = new Font("Segoe UI", 9),
                    AutoSize = true
                };

                // Edit Button
                System.Windows.Forms.Button btnEdit = new System.Windows.Forms.Button
                {
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    BackColor = ColorTranslator.FromHtml("#0066FF"),
                    Size = new Size(30, 30),
                    Location = new Point(255, 100),
                    Image = Properties.Resources.edit_1 // Use appropriate icon
                };

                btnEdit.Click += (s, e) =>
                {
                    var editForm = new frmEditUser(user, usersViewModel); // Pass the selected user and ViewModel
                    editForm.ShowDialog();

                    // Reload users after editing
                    DisplayUsers(usersViewModel.UsersList, currentPage);
                };


                // Delete Button
                System.Windows.Forms.Button btnDelete = new System.Windows.Forms.Button
                {
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    BackColor = ColorTranslator.FromHtml("#FF0000"),
                    Size = new Size(30, 30),
                    Location = new Point(290, 100),
                    Image = Properties.Resources.bin_1 // Use appropriate icon
                };

                // Attach the click event
                btnDelete.Click += (s, e) =>
                {
                    var confirmResult = MessageBox.Show("Are you sure to delete this user?",
                                                         "Confirm Delete!",
                                                         MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        usersViewModel.DeleteUser(user.LibrarianId);
                        DisplayUsers(usersViewModel.UsersList, currentPage); // Refresh the user list
                    }
                };

                // Add components to the userPanel
                userPanel.Controls.Add(profilePhoto);
                userPanel.Controls.Add(lblName);
                userPanel.Controls.Add(lblContact);
                userPanel.Controls.Add(lblEmail);
                userPanel.Controls.Add(lblOtherDetails);
                userPanel.Controls.Add(lblAddress);
                userPanel.Controls.Add(lblPosition);
                userPanel.Controls.Add(btnEdit);
                userPanel.Controls.Add(btnDelete);
                userPanel.Controls.Add(lblUsername);

                // Add userPanel to tableLayoutPanel1
                tableLayoutPanel1.Controls.Add(userPanel);
            }

            // Update pagination controls (if applicable)
            lblPage.Text = $"Page {currentPage} of {Math.Ceiling((double)usersList.Count / itemsPerPage)}";
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < Math.Ceiling((double)usersList.Count / itemsPerPage);

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Get the search query from the text box
            string searchQuery = txtSearch.Texts;

            // Call the SearchUsers method in UsersViewModel
            var filteredUsers = usersViewModel.SearchUsers(searchQuery);

            // Reset page number to 1 for a new search result
            currentPage = 1;

            // Display the filtered user list
            DisplayUsers(filteredUsers, currentPage);
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {

            frmAddUser addUserForm = new frmAddUser(usersViewModel);

            // Subscribe to the UserAdded event
            addUserForm.UserAdded += (s, args) =>
            {
                // Refresh the user list when a user is added
                DisplayUsers(usersViewModel.UsersList, currentPage);
            };

            // Show the form as a dialog
            addUserForm.ShowDialog();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--; // Move to the previous page
                DisplayUsers(usersViewModel.UsersList, currentPage); // Refresh the display with the updated page
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)usersViewModel.UsersList.Count / itemsPerPage);

            if (currentPage < totalPages)
            {
                currentPage++; // Move to the next page
                DisplayUsers(usersViewModel.UsersList, currentPage); // Refresh the display with the updated page
            }
        }
    }
}

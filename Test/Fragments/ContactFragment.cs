using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Test.Models;
using Test.Api;
using System.Net;
using Android.Graphics;
using Java.IO;
using System.IO;

namespace Test.Fragments
{
    public class ContactFragment : Fragment
    {
        private View view;

        private List<CheckBox> checkBoxs;

        private EditText firstName;

        private EditText lastName;

        private EditText email;

        private EditText company;

        private EditText position;

        private EditText branch;

        private EditText comments;

        private Spinner spinner;

        private string reason;

        private string imageBase64;

        private Contact contact = new Contact();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.ContactFragment, container, false);

            view.FindViewById<ImageButton>(Resource.Id.imebtn_takecard).Click += delegate
            {
                var intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
            };

            checkBoxs = new List<int>()
            {
                Resource.Id.checkBoxReason1,
                Resource.Id.checkBoxReason2,
                Resource.Id.checkBoxReason3,
                Resource.Id.checkBoxReason4
            }.Select(x => view.FindViewById<CheckBox>(x)).ToList();

            checkBoxs.ForEach(x => x.Click += CheckBox_Click);

            view.FindViewById<Button>(Resource.Id.buttonSend).Click += ButtonSend_Click;

            firstName = view.FindViewById<EditText>(Resource.Id.textViewFirstName);
            lastName = view.FindViewById<EditText>(Resource.Id.textViewLastName);
            email = view.FindViewById<EditText>(Resource.Id.textViewEmail);
            company = view.FindViewById<EditText>(Resource.Id.textViewCompany);
            position = view.FindViewById<EditText>(Resource.Id.textViewPosition);
            branch = view.FindViewById<EditText>(Resource.Id.textViewBranch);
            comments = view.FindViewById<EditText>(Resource.Id.textViewComments);

            spinner = view.FindViewById<Spinner>(Resource.Id.spinner1);
            spinner.Adapter = new ArrayAdapter<string>(view.Context, Android.Resource.Layout.SimpleSpinnerItem, new string[] { "Frédéric", "Markus", "Paul", "Kay", "Joël", "Pascal", "Mike", "Hoa Vo" });

            return view;
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                contact.Reason = reason;
                contact.HelloTo = checkBoxs[2].Checked ? spinner.SelectedItem.ToString() : "";
                contact.FirstName = firstName.Text;
                contact.LastName = lastName.Text;
                contact.Email = email.Text;
                contact.Company = company.Text;
                contact.Position = position.Text;
                contact.Industry = branch.Text;
                contact.Comments = comments.Text;
                contact.Token = "v5?1Q$Q974-tE_i1K!_!7qoiEo_?4@-35ptR57tedi66Mx-Duqm-2?x$j@zX6@U";
                contact.Images = string.IsNullOrEmpty(imageBase64) ? new List<Image>() : new List<Image>
                {
                    new Image
                    {
                        Id = 0,
                        ImageBase64 = imageBase64
                    }
                };

                try
                {
                    Swagger.Instance.PostContact(contact);
                    Toast.MakeText(view.Context, "Sent", ToastLength.Short).Show();
                }
                catch (WebException webException)
                {
                    Log.Debug("ApiError", $"Exception: {webException.Message}");
                    Toast.MakeText(view.Context, "Send failed", ToastLength.Short).Show();
                }
            } else
            {
                Toast.MakeText(view.Context, "Value empty", ToastLength.Short).Show();
            }
        }

        private bool Check() => checkBoxs.Any(x => x.Checked) && !string.IsNullOrEmpty(firstName.Text) && !string.IsNullOrEmpty(lastName.Text) && !string.IsNullOrEmpty(email.Text);

        private void InitCheckBoxs()
        {
            checkBoxs.ForEach(x => x.Checked = false);
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            InitCheckBoxs();

            switch(((View)sender).Id)
            {
                case Resource.Id.checkBoxReason1:
                    reason = "DIGITAL_PROJET";
                    checkBoxs[0].Checked = true;
                    break;
                case Resource.Id.checkBoxReason2:
                    reason = "JOB_OR_MASTER_THESIS";
                    checkBoxs[1].Checked = true;
                    break;
                case Resource.Id.checkBoxReason3:
                    checkBoxs[2].Checked = true;
                    reason = "SAY_HI";
                    break;
                case Resource.Id.checkBoxReason4:
                    reason = "OTHER";
                    checkBoxs[3].Checked = true;
                    break;
            }
        }

        public override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            view.FindViewById<ImageView>(Resource.Id.imev_card).SetImageBitmap((Bitmap)data.Extras.Get("data"));
            imageBase64 = BitMapToString((Bitmap)data.Extras.Get("data"));
        }

        private String BitMapToString(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                var bytes = stream.ToArray();
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
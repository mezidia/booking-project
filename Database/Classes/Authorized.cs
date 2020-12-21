﻿using System;
using hotel_booking.SqlConn;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_booking
{
	public class Authorized : User
	{
		// properties

		protected string Email { get; set; }
		protected string Login { get; set; }
		protected string Password { get; set; }

		protected int Age { get; set; }
		protected int PhoneNumber { get; set; }
		protected int Country { get; set; }
		protected int ID { get; set; }

		// methods

		public bool Book(object[] bookfields)
		{
			bool funcState = false;

			SqlConnection conn = DBConnConfig.GetDBConnection();
			conn.Open();

			try
			{
				SqlCommand cmd = new SqlCommand("SetBooking", conn);

				//Command type -> StoredProcedure
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Book", SqlDbType.Int).Value = bookfields[0];
				cmd.Parameters.Add("@User", SqlDbType.Int).Value = bookfields[1];
				cmd.Parameters.Add("@Room", SqlDbType.Int).Value = bookfields[2];
				cmd.Parameters.Add("@Description_str", SqlDbType.NVarChar).Value = bookfields[3];
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = hotelFields[4];
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = hotelFields[5];

				//exec procedure
				cmd.ExecuteNonQuery();
				funcState = true;
			}
			catch (Exception e)
			{
				//Console.log error
				Console.WriteLine("Error: " + e.Message);
				funcState = false;
			}

			conn.Close();
			conn.Dispose();

			return funcState;
		}

		public object[] CheckBookings(int id)
		{
			SqlConnection conn = DBConnConfig.GetDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetBooking", conn);

            // Вид Command является StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = id;

            // Выполнить процедуру.
            cmd.ExecuteNonQuery();

            object[] UserBookings = new object[9];

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    UserBookings[0] = int.Parse(rdr["book_id"].ToString());
                    UserBookings[1] = int.Parse(rdr["user_id"].ToString());
                    UserBookings[2] = int.Parse(rdr["room_id"].ToString());
                    UserBookings[3] = rdr["description_str"].ToString();
					UserBookings[4] = int.Parse(rdr["startDate_int"].ToString());
                    UserBookings[5] = int.Parse(rdr["endDate_int"].ToString());
                }
            }
            //output recieved data
            Console.WriteLine("Book id: " + UserBookings[0]);
            Console.WriteLine("User id: " + UserBookings[1]);
            Console.WriteLine("Room id: " + UserBookings[2]);
            Console.WriteLine("Description: " + UserBookings[3]);
            Console.WriteLine("Start date: " + UserBookings[4]);
            Console.WriteLine("End date: " + UserBookings[5]);

            conn.Close();
            conn.Dispose();

            return UserData;
		}

		public void Review(object[] reviewfields)
		{
			bool funcState = false;

			SqlConnection conn = DBConnConfig.GetDBConnection();
			conn.Open();

			try
			{
				SqlCommand cmd = new SqlCommand("SetReview", conn);

				//Command type -> StoredProcedure
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = reviewfields[0];
				cmd.Parameters.Add("@HotelID", SqlDbType.Int).Value = reviewfields[1];
				cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = reviewfields[2];
				cmd.Parameters.Add("@Review", SqlDbType.NVarChar).Value = reviewfields[3];
				cmd.Parameters.Add("@CreationDate", SqlDbType.DateTime).Value = reviewfields[4];

				//exec procedure
				cmd.ExecuteNonQuery();
				funcState = true;
			}
			catch (Exception e)
			{
				//Console.log error
				Console.WriteLine("Error: " + e.Message);
				funcState = false;
			}

			conn.Close();
			conn.Dispose();

			return funcState;
		}

		public void CancelBooking()
		{

		}

		public void ReceiveEmails()
		{

		}

		public void ReportReviews()
		{

		}

		public void LogOut()
		{

		}

		public bool AddHotel(object[] fields)
		{
			SqlConnection conn = DBConnConfig.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand("SetHotel", conn);

			// Вид Command является StoredProcedure
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@HotelID", SqlDbType.Int).Value = id;

			// Выполнить процедуру.
			cmd.ExecuteNonQuery();

			object[] HotelData = new object[8];

			using (SqlDataReader rdr = cmd.ExecuteReader())
			{
				while (rdr.Read())
				{
					HotelData[0] = int.Parse(rdr["country_id"].ToString());
					HotelData[1] = int.Parse(rdr["owner_id"].ToString());
					HotelData[2] = int.Parse(rdr["number_of_stars_int"].ToString());
					HotelData[3] = rdr["description_str"].ToString();
					HotelData[4] = int.Parse(rdr["location_int"].ToString());
					HotelData[5] = int.Parse(rdr["hotelType_int"].ToString());
					HotelData[6] = int.Parse(rdr["rating_int"].ToString());
					HotelData[7] = rdr["hotelName_str"].ToString();
				}
			}
			//output recieved data
			Console.WriteLine("country: " + HotelData[0]);
			Console.WriteLine("owner id: " + HotelData[1]);
			Console.WriteLine("number of stars: " + HotelData[2]);
			Console.WriteLine("description: " + HotelData[3]);
			Console.WriteLine("location: " + HotelData[4]);
			Console.WriteLine("hotel type: " + HotelData[5]);
			Console.WriteLine("rating: " + HotelData[6]);
			Console.WriteLine("hotel name: " + HotelData[7]);
			return HotelData;
			return true;
		}
	}
}

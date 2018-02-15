using DevTestCommon;
using NHibernate;
using System;

namespace DevTestData {

	/// <summary>
	/// Datanbank-Layer für Benutzer.
	/// </summary>
	public class UserDalc : BaseDalc {

		/// <summary>
		/// Laden
		/// </summary>
		public User Get(int id) {
			ISession session = SessionFactory.OpenSession();
			return session.Get<User>(id);
		}

		/// <summary>
		/// Speichern
		/// </summary>
		public int Save(User user) {
			ISession session = SessionFactory.OpenSession();
			if (user.Version > 0) {
				user.ModifiedOnUtc = DateTime.UtcNow;
			}
			int id = (int)session.Save(user);
			session.Flush();
			return id;
		}

		/// <summary>
		/// Speichern oder aktualisieren
		/// </summary>
		public void SaveOrUpdate(User user) {
			ISession session = SessionFactory.OpenSession();
			if (user.Version > 0) {
				user.ModifiedOnUtc = DateTime.UtcNow;
			}
			session.SaveOrUpdate(user);
			session.Flush();
		}

	}
}

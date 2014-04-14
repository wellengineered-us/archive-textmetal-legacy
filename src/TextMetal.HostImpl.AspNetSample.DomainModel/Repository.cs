﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

using TextMetal.Common.Cerealization;
using TextMetal.Common.Core;
using TextMetal.Common.Data;
using TextMetal.Common.Data.LinqToSql;
using TextMetal.HostImpl.AspNetSample.Common;
using TextMetal.HostImpl.AspNetSample.DomainModel.Tables;
using TextMetal.HostImpl.AspNetSample.DomainModel.Views;
using TextMetal.HostImpl.Web.Email;

namespace TextMetal.HostImpl.AspNetSample.DomainModel
{
	public partial class Repository
	{
		#region Methods/Operators

		public static XElement ToXElement(XmlDocument xmlDocument)
		{
			if ((object)xmlDocument == null)
				throw new ArgumentNullException("xmlDocument");

			using (XmlNodeReader nodeReader = new XmlNodeReader(xmlDocument))
			{
				nodeReader.MoveToContent();
				return XElement.Load(nodeReader);
			}
		}

		public static XmlDocument ToXmlDocument(XElement xElement)
		{
			XmlDocument xmlDocument;

			if ((object)xElement == null)
				throw new ArgumentNullException("xElement");

			xmlDocument = new XmlDocument();

			using (XmlReader xmlReader = xElement.CreateReader())
				xmlDocument.Load(xmlReader);

			return xmlDocument;
		}

		public IEnumerable<TResultEntity> Find<TDataContext, TResultEntity>(TDataContext dummy, Func<TDataContext, IQueryable<TResultEntity>> callback)
			where TDataContext : class, IDisposable
		{
			IEnumerable<TResultEntity> things;

			if ((object)UnitOfWork.Current == null)
			{
				using (IUnitOfWork unitOfWork = DefaultUnitOfWorkFactory.Instance.GetUnitOfWork())
				{
					things = this.Find<TDataContext, TResultEntity>(dummy, unitOfWork, callback);

					things = things.ToList(); // FORCE EAGER LOAD

					unitOfWork.Complete();
				}
			}
			else
			{
				things = this.Find<TDataContext, TResultEntity>(dummy, UnitOfWork.Current, callback);

				// DO NOT FORCE EAGER LOAD
			}

			return things;
		}

		public IEnumerable<TResultEntity> Find<TDataContext, TResultEntity>(TDataContext dummy, IUnitOfWork unitOfWork, Func<TDataContext, IQueryable<TResultEntity>> callback)
			where TDataContext : class, IDisposable
		{
			IEnumerable<TResultEntity> things;
			IQueryable<TResultEntity> queryable;

			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)callback == null)
				throw new ArgumentNullException("callback");

			using (AmbientUnitOfWorkAwareDisposableWrapper<TDataContext> wrapper = unitOfWork.GetContext<TDataContext>())
			{
				queryable = callback(wrapper.Disposable);

				if ((object)queryable == null)
					throw new InvalidOperationException(string.Format("The queryable returned was invalid."));

				things = queryable; // DOES NOT FORCE EXECUTION AGAINST STORE

				foreach (TResultEntity thing in things)
				{
					//this.OnSelect(unitOfWork, thing);
					//thing.Mark();
					yield return thing; // LAZY PROCESSING INTENT HERE / DO NOT FORCE EAGER LOAD
				}
			}
		}

		public IEnumerable<IListItem<int?>> GetSecurityRoles()
		{
			List<IListItem<int?>> securityRoles;

			securityRoles = new List<IListItem<int?>>();
			securityRoles.Add(new ListItem<int?>((int?)SecurityRoleEnum.None, SecurityRoleEnum.None.ToString()));
			securityRoles.Add(new ListItem<int?>((int?)SecurityRoleEnum.OrganizationVisitor, SecurityRoleEnum.OrganizationVisitor.ToString()));
			securityRoles.Add(new ListItem<int?>((int?)SecurityRoleEnum.OrganizationContributor, SecurityRoleEnum.OrganizationContributor.ToString()));
			securityRoles.Add(new ListItem<int?>((int?)SecurityRoleEnum.OrganizationDesigner, SecurityRoleEnum.OrganizationDesigner.ToString()));
			securityRoles.Add(new ListItem<int?>((int?)SecurityRoleEnum.OrganizationOwner, SecurityRoleEnum.OrganizationOwner.ToString()));

			return securityRoles;
		}

		partial void OnPreInsertOrganization(IUnitOfWork unitOfWork, Organization @organization)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organization == null)
				throw new ArgumentNullException("@organization");

			@organization.Mark();
		}

		partial void OnPostInsertOrganization(IUnitOfWork unitOfWork, Organization @organization)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organization == null)
				throw new ArgumentNullException("@organization");

			// do nothing
		}

		partial void OnPreUpdateOrganization(IUnitOfWork unitOfWork, Organization @organization)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organization == null)
				throw new ArgumentNullException("@organization");

			@organization.Mark();
		}

		partial void OnPostUpdateOrganization(IUnitOfWork unitOfWork, Organization @organization)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organization == null)
				throw new ArgumentNullException("@organization");

			// do nothing
		}

		partial void OnPreDeleteOrganization(IUnitOfWork unitOfWork, Organization @organization)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organization == null)
				throw new ArgumentNullException("@organization");

			// do nothing
		}

		partial void OnPostDeleteOrganization(IUnitOfWork unitOfWork, Organization @organization)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organization == null)
				throw new ArgumentNullException("@organization");

			// do nothing
		}

		partial void OnSaveConflictOrganization(IUnitOfWork unitOfWork, Organization @organization)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organization == null)
				throw new ArgumentNullException("@organization");

			// do nothing
		}

		partial void OnDiscardConflictOrganization(IUnitOfWork unitOfWork, Organization @organization)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organization == null)
				throw new ArgumentNullException("@organization");

			// do nothing
		}

		partial void OnSelectOrganization(IUnitOfWork unitOfWork, Organization @organization)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organization == null)
				throw new ArgumentNullException("@organization");

			// do nothing
		}


		partial void OnPreInsertMember(IUnitOfWork unitOfWork, Member @member)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@member == null)
				throw new ArgumentNullException("@member");

			@member.Mark();
		}

		partial void OnPostInsertMember(IUnitOfWork unitOfWork, Member @member)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@member == null)
				throw new ArgumentNullException("@member");

			// do nothing
		}

		partial void OnPreUpdateMember(IUnitOfWork unitOfWork, Member @member)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@member == null)
				throw new ArgumentNullException("@member");

			@member.Mark();
		}

		partial void OnPostUpdateMember(IUnitOfWork unitOfWork, Member @member)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@member == null)
				throw new ArgumentNullException("@member");

			// do nothing
		}

		partial void OnPreDeleteMember(IUnitOfWork unitOfWork, Member @member)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@member == null)
				throw new ArgumentNullException("@member");

			// do nothing
		}

		partial void OnPostDeleteMember(IUnitOfWork unitOfWork, Member @member)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@member == null)
				throw new ArgumentNullException("@member");

			// do nothing
		}

		partial void OnSaveConflictMember(IUnitOfWork unitOfWork, Member @member)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@member == null)
				throw new ArgumentNullException("@member");

			// do nothing
		}

		partial void OnDiscardConflictMember(IUnitOfWork unitOfWork, Member @member)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@member == null)
				throw new ArgumentNullException("@member");

			// do nothing
		}

		partial void OnSelectMember(IUnitOfWork unitOfWork, Member @member)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@member == null)
				throw new ArgumentNullException("@member");

			// do nothing
		}

		partial void OnPreInsertEventLogExtent(IUnitOfWork unitOfWork, EventLogExtent @eventLogExtent)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogExtent == null)
				throw new ArgumentNullException("@eventLogExtent");

			@eventLogExtent.Mark();
		}

		partial void OnPostInsertEventLogExtent(IUnitOfWork unitOfWork, EventLogExtent @eventLogExtent)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogExtent == null)
				throw new ArgumentNullException("@eventLogExtent");

			// do nothing
		}

		partial void OnPreUpdateEventLogExtent(IUnitOfWork unitOfWork, EventLogExtent @eventLogExtent)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogExtent == null)
				throw new ArgumentNullException("@eventLogExtent");

			@eventLogExtent.Mark();
		}

		partial void OnPostUpdateEventLogExtent(IUnitOfWork unitOfWork, EventLogExtent @eventLogExtent)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogExtent == null)
				throw new ArgumentNullException("@eventLogExtent");

			// do nothing
		}

		partial void OnPreDeleteEventLogExtent(IUnitOfWork unitOfWork, EventLogExtent @eventLogExtent)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogExtent == null)
				throw new ArgumentNullException("@eventLogExtent");

			// do nothing
		}

		partial void OnPostDeleteEventLogExtent(IUnitOfWork unitOfWork, EventLogExtent @eventLogExtent)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogExtent == null)
				throw new ArgumentNullException("@eventLogExtent");

			// do nothing
		}

		partial void OnSaveConflictEventLogExtent(IUnitOfWork unitOfWork, EventLogExtent @eventLogExtent)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogExtent == null)
				throw new ArgumentNullException("@eventLogExtent");

			// do nothing
		}

		partial void OnDiscardConflictEventLogExtent(IUnitOfWork unitOfWork, EventLogExtent @eventLogExtent)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogExtent == null)
				throw new ArgumentNullException("@eventLogExtent");

			// do nothing
		}

		partial void OnSelectEventLogExtent(IUnitOfWork unitOfWork, EventLogExtent @eventLogExtent)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogExtent == null)
				throw new ArgumentNullException("@eventLogExtent");

			// do nothing
		}

		partial void OnPreInsertUser(IUnitOfWork unitOfWork, User @user)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@user == null)
				throw new ArgumentNullException("@user");

			@user.Mark();
		}

		partial void OnPostInsertUser(IUnitOfWork unitOfWork, User @user)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@user == null)
				throw new ArgumentNullException("@user");

			// do nothing
		}

		partial void OnPreUpdateUser(IUnitOfWork unitOfWork, User @user)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@user == null)
				throw new ArgumentNullException("@user");

			@user.Mark();
		}

		partial void OnPostUpdateUser(IUnitOfWork unitOfWork, User @user)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@user == null)
				throw new ArgumentNullException("@user");

			// do nothing
		}

		partial void OnPreDeleteUser(IUnitOfWork unitOfWork, User @user)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@user == null)
				throw new ArgumentNullException("@user");

			// do nothing
		}

		partial void OnPostDeleteUser(IUnitOfWork unitOfWork, User @user)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@user == null)
				throw new ArgumentNullException("@user");

			// do nothing
		}

		partial void OnSaveConflictUser(IUnitOfWork unitOfWork, User @user)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@user == null)
				throw new ArgumentNullException("@user");

			// do nothing
		}

		partial void OnDiscardConflictUser(IUnitOfWork unitOfWork, User @user)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@user == null)
				throw new ArgumentNullException("@user");

			// do nothing
		}

		partial void OnSelectUser(IUnitOfWork unitOfWork, User @user)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@user == null)
				throw new ArgumentNullException("@user");

			// do nothing
		}


		partial void OnPreInsertSecurityRole(IUnitOfWork unitOfWork, SecurityRole @securityRole)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRole == null)
				throw new ArgumentNullException("@securityRole");

			@securityRole.Mark();
		}

		partial void OnPostInsertSecurityRole(IUnitOfWork unitOfWork, SecurityRole @securityRole)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRole == null)
				throw new ArgumentNullException("@securityRole");

			// do nothing
		}

		partial void OnPreUpdateSecurityRole(IUnitOfWork unitOfWork, SecurityRole @securityRole)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRole == null)
				throw new ArgumentNullException("@securityRole");

			@securityRole.Mark();
		}

		partial void OnPostUpdateSecurityRole(IUnitOfWork unitOfWork, SecurityRole @securityRole)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRole == null)
				throw new ArgumentNullException("@securityRole");

			// do nothing
		}

		partial void OnPreDeleteSecurityRole(IUnitOfWork unitOfWork, SecurityRole @securityRole)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRole == null)
				throw new ArgumentNullException("@securityRole");

			// do nothing
		}

		partial void OnPostDeleteSecurityRole(IUnitOfWork unitOfWork, SecurityRole @securityRole)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRole == null)
				throw new ArgumentNullException("@securityRole");

			// do nothing
		}

		partial void OnSaveConflictSecurityRole(IUnitOfWork unitOfWork, SecurityRole @securityRole)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRole == null)
				throw new ArgumentNullException("@securityRole");

			// do nothing
		}

		partial void OnDiscardConflictSecurityRole(IUnitOfWork unitOfWork, SecurityRole @securityRole)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRole == null)
				throw new ArgumentNullException("@securityRole");

			// do nothing
		}

		partial void OnSelectSecurityRole(IUnitOfWork unitOfWork, SecurityRole @securityRole)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRole == null)
				throw new ArgumentNullException("@securityRole");

			// do nothing
		}


		partial void OnPreInsertPropertyBag(IUnitOfWork unitOfWork, PropertyBag @propertyBag)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBag == null)
				throw new ArgumentNullException("@propertyBag");

			@propertyBag.Mark();
		}

		partial void OnPostInsertPropertyBag(IUnitOfWork unitOfWork, PropertyBag @propertyBag)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBag == null)
				throw new ArgumentNullException("@propertyBag");

			// do nothing
		}

		partial void OnPreUpdatePropertyBag(IUnitOfWork unitOfWork, PropertyBag @propertyBag)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBag == null)
				throw new ArgumentNullException("@propertyBag");

			@propertyBag.Mark();
		}

		partial void OnPostUpdatePropertyBag(IUnitOfWork unitOfWork, PropertyBag @propertyBag)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBag == null)
				throw new ArgumentNullException("@propertyBag");

			// do nothing
		}

		partial void OnPreDeletePropertyBag(IUnitOfWork unitOfWork, PropertyBag @propertyBag)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBag == null)
				throw new ArgumentNullException("@propertyBag");

			// do nothing
		}

		partial void OnPostDeletePropertyBag(IUnitOfWork unitOfWork, PropertyBag @propertyBag)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBag == null)
				throw new ArgumentNullException("@propertyBag");

			// do nothing
		}

		partial void OnSaveConflictPropertyBag(IUnitOfWork unitOfWork, PropertyBag @propertyBag)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBag == null)
				throw new ArgumentNullException("@propertyBag");

			// do nothing
		}

		partial void OnDiscardConflictPropertyBag(IUnitOfWork unitOfWork, PropertyBag @propertyBag)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBag == null)
				throw new ArgumentNullException("@propertyBag");

			// do nothing
		}

		partial void OnSelectPropertyBag(IUnitOfWork unitOfWork, PropertyBag @propertyBag)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBag == null)
				throw new ArgumentNullException("@propertyBag");

			// do nothing
		}


		partial void OnPreInsertEventLog(IUnitOfWork unitOfWork, EventLog @eventLog)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLog == null)
				throw new ArgumentNullException("@eventLog");

			@eventLog.Mark();
		}

		partial void OnPostInsertEventLog(IUnitOfWork unitOfWork, EventLog @eventLog)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLog == null)
				throw new ArgumentNullException("@eventLog");

			// do nothing
		}

		partial void OnPreUpdateEventLog(IUnitOfWork unitOfWork, EventLog @eventLog)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLog == null)
				throw new ArgumentNullException("@eventLog");

			@eventLog.Mark();
		}

		partial void OnPostUpdateEventLog(IUnitOfWork unitOfWork, EventLog @eventLog)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLog == null)
				throw new ArgumentNullException("@eventLog");

			// do nothing
		}

		partial void OnPreDeleteEventLog(IUnitOfWork unitOfWork, EventLog @eventLog)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLog == null)
				throw new ArgumentNullException("@eventLog");

			// do nothing
		}

		partial void OnPostDeleteEventLog(IUnitOfWork unitOfWork, EventLog @eventLog)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLog == null)
				throw new ArgumentNullException("@eventLog");

			// do nothing
		}

		partial void OnSaveConflictEventLog(IUnitOfWork unitOfWork, EventLog @eventLog)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLog == null)
				throw new ArgumentNullException("@eventLog");

			// do nothing
		}

		partial void OnDiscardConflictEventLog(IUnitOfWork unitOfWork, EventLog @eventLog)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLog == null)
				throw new ArgumentNullException("@eventLog");

			// do nothing
		}

		partial void OnSelectEventLog(IUnitOfWork unitOfWork, EventLog @eventLog)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLog == null)
				throw new ArgumentNullException("@eventLog");

			// do nothing
		}


		partial void OnPreInsertEmailMessage(IUnitOfWork unitOfWork, EmailMessage @emailMessage)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessage == null)
				throw new ArgumentNullException("@emailMessage");

			@emailMessage.Mark();
		}

		partial void OnPostInsertEmailMessage(IUnitOfWork unitOfWork, EmailMessage @emailMessage)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessage == null)
				throw new ArgumentNullException("@emailMessage");

			// do nothing
		}

		partial void OnPreUpdateEmailMessage(IUnitOfWork unitOfWork, EmailMessage @emailMessage)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessage == null)
				throw new ArgumentNullException("@emailMessage");

			@emailMessage.Mark();
		}

		partial void OnPostUpdateEmailMessage(IUnitOfWork unitOfWork, EmailMessage @emailMessage)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessage == null)
				throw new ArgumentNullException("@emailMessage");

			// do nothing
		}

		partial void OnPreDeleteEmailMessage(IUnitOfWork unitOfWork, EmailMessage @emailMessage)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessage == null)
				throw new ArgumentNullException("@emailMessage");

			// do nothing
		}

		partial void OnPostDeleteEmailMessage(IUnitOfWork unitOfWork, EmailMessage @emailMessage)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessage == null)
				throw new ArgumentNullException("@emailMessage");

			// do nothing
		}

		partial void OnSaveConflictEmailMessage(IUnitOfWork unitOfWork, EmailMessage @emailMessage)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessage == null)
				throw new ArgumentNullException("@emailMessage");

			// do nothing
		}

		partial void OnDiscardConflictEmailMessage(IUnitOfWork unitOfWork, EmailMessage @emailMessage)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessage == null)
				throw new ArgumentNullException("@emailMessage");

			// do nothing
		}

		partial void OnSelectEmailMessage(IUnitOfWork unitOfWork, EmailMessage @emailMessage)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessage == null)
				throw new ArgumentNullException("@emailMessage");

			// do nothing
		}


		partial void OnPreInsertEmailAttachment(IUnitOfWork unitOfWork, EmailAttachment @emailAttachment)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachment == null)
				throw new ArgumentNullException("@emailAttachment");

			@emailAttachment.Mark();
		}

		partial void OnPostInsertEmailAttachment(IUnitOfWork unitOfWork, EmailAttachment @emailAttachment)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachment == null)
				throw new ArgumentNullException("@emailAttachment");

			// do nothing
		}

		partial void OnPreUpdateEmailAttachment(IUnitOfWork unitOfWork, EmailAttachment @emailAttachment)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachment == null)
				throw new ArgumentNullException("@emailAttachment");

			@emailAttachment.Mark();
		}

		partial void OnPostUpdateEmailAttachment(IUnitOfWork unitOfWork, EmailAttachment @emailAttachment)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachment == null)
				throw new ArgumentNullException("@emailAttachment");

			// do nothing
		}

		partial void OnPreDeleteEmailAttachment(IUnitOfWork unitOfWork, EmailAttachment @emailAttachment)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachment == null)
				throw new ArgumentNullException("@emailAttachment");

			// do nothing
		}

		partial void OnPostDeleteEmailAttachment(IUnitOfWork unitOfWork, EmailAttachment @emailAttachment)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachment == null)
				throw new ArgumentNullException("@emailAttachment");

			// do nothing
		}

		partial void OnSaveConflictEmailAttachment(IUnitOfWork unitOfWork, EmailAttachment @emailAttachment)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachment == null)
				throw new ArgumentNullException("@emailAttachment");

			// do nothing
		}

		partial void OnDiscardConflictEmailAttachment(IUnitOfWork unitOfWork, EmailAttachment @emailAttachment)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachment == null)
				throw new ArgumentNullException("@emailAttachment");

			// do nothing
		}

		partial void OnSelectEmailAttachment(IUnitOfWork unitOfWork, EmailAttachment @emailAttachment)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachment == null)
				throw new ArgumentNullException("@emailAttachment");

			// do nothing
		}

		partial void OnPreInsertOrganizationHistory(IUnitOfWork unitOfWork, OrganizationHistory @organizationHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organizationHistory == null)
				throw new ArgumentNullException("@organizationHistory");

			@organizationHistory.Mark();
		}

		partial void OnPostInsertOrganizationHistory(IUnitOfWork unitOfWork, OrganizationHistory @organizationHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organizationHistory == null)
				throw new ArgumentNullException("@organizationHistory");

			// do nothing
		}

		partial void OnPreUpdateOrganizationHistory(IUnitOfWork unitOfWork, OrganizationHistory @organizationHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organizationHistory == null)
				throw new ArgumentNullException("@organizationHistory");

			@organizationHistory.Mark();
		}

		partial void OnPostUpdateOrganizationHistory(IUnitOfWork unitOfWork, OrganizationHistory @organizationHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organizationHistory == null)
				throw new ArgumentNullException("@organizationHistory");

			// do nothing
		}

		partial void OnPreDeleteOrganizationHistory(IUnitOfWork unitOfWork, OrganizationHistory @organizationHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organizationHistory == null)
				throw new ArgumentNullException("@organizationHistory");

			// do nothing
		}

		partial void OnPostDeleteOrganizationHistory(IUnitOfWork unitOfWork, OrganizationHistory @organizationHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organizationHistory == null)
				throw new ArgumentNullException("@organizationHistory");

			// do nothing
		}

		partial void OnSaveConflictOrganizationHistory(IUnitOfWork unitOfWork, OrganizationHistory @organizationHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organizationHistory == null)
				throw new ArgumentNullException("@organizationHistory");

			// do nothing
		}

		partial void OnDiscardConflictOrganizationHistory(IUnitOfWork unitOfWork, OrganizationHistory @organizationHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organizationHistory == null)
				throw new ArgumentNullException("@organizationHistory");

			// do nothing
		}

		partial void OnSelectOrganizationHistory(IUnitOfWork unitOfWork, OrganizationHistory @organizationHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@organizationHistory == null)
				throw new ArgumentNullException("@organizationHistory");

			// do nothing
		}


		partial void OnPreInsertMemberHistory(IUnitOfWork unitOfWork, MemberHistory @memberHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@memberHistory == null)
				throw new ArgumentNullException("@memberHistory");

			@memberHistory.Mark();
		}

		partial void OnPostInsertMemberHistory(IUnitOfWork unitOfWork, MemberHistory @memberHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@memberHistory == null)
				throw new ArgumentNullException("@memberHistory");

			// do nothing
		}

		partial void OnPreUpdateMemberHistory(IUnitOfWork unitOfWork, MemberHistory @memberHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@memberHistory == null)
				throw new ArgumentNullException("@memberHistory");

			@memberHistory.Mark();
		}

		partial void OnPostUpdateMemberHistory(IUnitOfWork unitOfWork, MemberHistory @memberHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@memberHistory == null)
				throw new ArgumentNullException("@memberHistory");

			// do nothing
		}

		partial void OnPreDeleteMemberHistory(IUnitOfWork unitOfWork, MemberHistory @memberHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@memberHistory == null)
				throw new ArgumentNullException("@memberHistory");

			// do nothing
		}

		partial void OnPostDeleteMemberHistory(IUnitOfWork unitOfWork, MemberHistory @memberHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@memberHistory == null)
				throw new ArgumentNullException("@memberHistory");

			// do nothing
		}

		partial void OnSaveConflictMemberHistory(IUnitOfWork unitOfWork, MemberHistory @memberHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@memberHistory == null)
				throw new ArgumentNullException("@memberHistory");

			// do nothing
		}

		partial void OnDiscardConflictMemberHistory(IUnitOfWork unitOfWork, MemberHistory @memberHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@memberHistory == null)
				throw new ArgumentNullException("@memberHistory");

			// do nothing
		}

		partial void OnSelectMemberHistory(IUnitOfWork unitOfWork, MemberHistory @memberHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@memberHistory == null)
				throw new ArgumentNullException("@memberHistory");

			// do nothing
		}


		partial void OnPreInsertUserHistory(IUnitOfWork unitOfWork, UserHistory @userHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@userHistory == null)
				throw new ArgumentNullException("@userHistory");

			@userHistory.Mark();
		}

		partial void OnPostInsertUserHistory(IUnitOfWork unitOfWork, UserHistory @userHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@userHistory == null)
				throw new ArgumentNullException("@userHistory");

			// do nothing
		}

		partial void OnPreUpdateUserHistory(IUnitOfWork unitOfWork, UserHistory @userHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@userHistory == null)
				throw new ArgumentNullException("@userHistory");

			@userHistory.Mark();
		}

		partial void OnPostUpdateUserHistory(IUnitOfWork unitOfWork, UserHistory @userHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@userHistory == null)
				throw new ArgumentNullException("@userHistory");

			// do nothing
		}

		partial void OnPreDeleteUserHistory(IUnitOfWork unitOfWork, UserHistory @userHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@userHistory == null)
				throw new ArgumentNullException("@userHistory");

			// do nothing
		}

		partial void OnPostDeleteUserHistory(IUnitOfWork unitOfWork, UserHistory @userHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@userHistory == null)
				throw new ArgumentNullException("@userHistory");

			// do nothing
		}

		partial void OnSaveConflictUserHistory(IUnitOfWork unitOfWork, UserHistory @userHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@userHistory == null)
				throw new ArgumentNullException("@userHistory");

			// do nothing
		}

		partial void OnDiscardConflictUserHistory(IUnitOfWork unitOfWork, UserHistory @userHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@userHistory == null)
				throw new ArgumentNullException("@userHistory");

			// do nothing
		}

		partial void OnSelectUserHistory(IUnitOfWork unitOfWork, UserHistory @userHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@userHistory == null)
				throw new ArgumentNullException("@userHistory");

			// do nothing
		}


		partial void OnPreInsertSecurityRoleHistory(IUnitOfWork unitOfWork, SecurityRoleHistory @securityRoleHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRoleHistory == null)
				throw new ArgumentNullException("@securityRoleHistory");

			@securityRoleHistory.Mark();
		}

		partial void OnPostInsertSecurityRoleHistory(IUnitOfWork unitOfWork, SecurityRoleHistory @securityRoleHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRoleHistory == null)
				throw new ArgumentNullException("@securityRoleHistory");

			// do nothing
		}

		partial void OnPreUpdateSecurityRoleHistory(IUnitOfWork unitOfWork, SecurityRoleHistory @securityRoleHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRoleHistory == null)
				throw new ArgumentNullException("@securityRoleHistory");

			@securityRoleHistory.Mark();
		}

		partial void OnPostUpdateSecurityRoleHistory(IUnitOfWork unitOfWork, SecurityRoleHistory @securityRoleHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRoleHistory == null)
				throw new ArgumentNullException("@securityRoleHistory");

			// do nothing
		}

		partial void OnPreDeleteSecurityRoleHistory(IUnitOfWork unitOfWork, SecurityRoleHistory @securityRoleHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRoleHistory == null)
				throw new ArgumentNullException("@securityRoleHistory");

			// do nothing
		}

		partial void OnPostDeleteSecurityRoleHistory(IUnitOfWork unitOfWork, SecurityRoleHistory @securityRoleHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRoleHistory == null)
				throw new ArgumentNullException("@securityRoleHistory");

			// do nothing
		}

		partial void OnSaveConflictSecurityRoleHistory(IUnitOfWork unitOfWork, SecurityRoleHistory @securityRoleHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRoleHistory == null)
				throw new ArgumentNullException("@securityRoleHistory");

			// do nothing
		}

		partial void OnDiscardConflictSecurityRoleHistory(IUnitOfWork unitOfWork, SecurityRoleHistory @securityRoleHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRoleHistory == null)
				throw new ArgumentNullException("@securityRoleHistory");

			// do nothing
		}

		partial void OnSelectSecurityRoleHistory(IUnitOfWork unitOfWork, SecurityRoleHistory @securityRoleHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@securityRoleHistory == null)
				throw new ArgumentNullException("@securityRoleHistory");

			// do nothing
		}


		partial void OnPreInsertPropertyBagHistory(IUnitOfWork unitOfWork, PropertyBagHistory @propertyBagHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBagHistory == null)
				throw new ArgumentNullException("@propertyBagHistory");

			@propertyBagHistory.Mark();
		}

		partial void OnPostInsertPropertyBagHistory(IUnitOfWork unitOfWork, PropertyBagHistory @propertyBagHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBagHistory == null)
				throw new ArgumentNullException("@propertyBagHistory");

			// do nothing
		}

		partial void OnPreUpdatePropertyBagHistory(IUnitOfWork unitOfWork, PropertyBagHistory @propertyBagHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBagHistory == null)
				throw new ArgumentNullException("@propertyBagHistory");

			@propertyBagHistory.Mark();
		}

		partial void OnPostUpdatePropertyBagHistory(IUnitOfWork unitOfWork, PropertyBagHistory @propertyBagHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBagHistory == null)
				throw new ArgumentNullException("@propertyBagHistory");

			// do nothing
		}

		partial void OnPreDeletePropertyBagHistory(IUnitOfWork unitOfWork, PropertyBagHistory @propertyBagHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBagHistory == null)
				throw new ArgumentNullException("@propertyBagHistory");

			// do nothing
		}

		partial void OnPostDeletePropertyBagHistory(IUnitOfWork unitOfWork, PropertyBagHistory @propertyBagHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBagHistory == null)
				throw new ArgumentNullException("@propertyBagHistory");

			// do nothing
		}

		partial void OnSaveConflictPropertyBagHistory(IUnitOfWork unitOfWork, PropertyBagHistory @propertyBagHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBagHistory == null)
				throw new ArgumentNullException("@propertyBagHistory");

			// do nothing
		}

		partial void OnDiscardConflictPropertyBagHistory(IUnitOfWork unitOfWork, PropertyBagHistory @propertyBagHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBagHistory == null)
				throw new ArgumentNullException("@propertyBagHistory");

			// do nothing
		}

		partial void OnSelectPropertyBagHistory(IUnitOfWork unitOfWork, PropertyBagHistory @propertyBagHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@propertyBagHistory == null)
				throw new ArgumentNullException("@propertyBagHistory");

			// do nothing
		}


		partial void OnPreInsertEventLogHistory(IUnitOfWork unitOfWork, EventLogHistory @eventLogHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogHistory == null)
				throw new ArgumentNullException("@eventLogHistory");

			@eventLogHistory.Mark();
		}

		partial void OnPostInsertEventLogHistory(IUnitOfWork unitOfWork, EventLogHistory @eventLogHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogHistory == null)
				throw new ArgumentNullException("@eventLogHistory");

			// do nothing
		}

		partial void OnPreUpdateEventLogHistory(IUnitOfWork unitOfWork, EventLogHistory @eventLogHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogHistory == null)
				throw new ArgumentNullException("@eventLogHistory");

			@eventLogHistory.Mark();
		}

		partial void OnPostUpdateEventLogHistory(IUnitOfWork unitOfWork, EventLogHistory @eventLogHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogHistory == null)
				throw new ArgumentNullException("@eventLogHistory");

			// do nothing
		}

		partial void OnPreDeleteEventLogHistory(IUnitOfWork unitOfWork, EventLogHistory @eventLogHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogHistory == null)
				throw new ArgumentNullException("@eventLogHistory");

			// do nothing
		}

		partial void OnPostDeleteEventLogHistory(IUnitOfWork unitOfWork, EventLogHistory @eventLogHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogHistory == null)
				throw new ArgumentNullException("@eventLogHistory");

			// do nothing
		}

		partial void OnSaveConflictEventLogHistory(IUnitOfWork unitOfWork, EventLogHistory @eventLogHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogHistory == null)
				throw new ArgumentNullException("@eventLogHistory");

			// do nothing
		}

		partial void OnDiscardConflictEventLogHistory(IUnitOfWork unitOfWork, EventLogHistory @eventLogHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogHistory == null)
				throw new ArgumentNullException("@eventLogHistory");

			// do nothing
		}

		partial void OnSelectEventLogHistory(IUnitOfWork unitOfWork, EventLogHistory @eventLogHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@eventLogHistory == null)
				throw new ArgumentNullException("@eventLogHistory");

			// do nothing
		}


		partial void OnPreInsertEmailMessageHistory(IUnitOfWork unitOfWork, EmailMessageHistory @emailMessageHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessageHistory == null)
				throw new ArgumentNullException("@emailMessageHistory");

			@emailMessageHistory.Mark();
		}

		partial void OnPostInsertEmailMessageHistory(IUnitOfWork unitOfWork, EmailMessageHistory @emailMessageHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessageHistory == null)
				throw new ArgumentNullException("@emailMessageHistory");

			// do nothing
		}

		partial void OnPreUpdateEmailMessageHistory(IUnitOfWork unitOfWork, EmailMessageHistory @emailMessageHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessageHistory == null)
				throw new ArgumentNullException("@emailMessageHistory");

			@emailMessageHistory.Mark();
		}

		partial void OnPostUpdateEmailMessageHistory(IUnitOfWork unitOfWork, EmailMessageHistory @emailMessageHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessageHistory == null)
				throw new ArgumentNullException("@emailMessageHistory");

			// do nothing
		}

		partial void OnPreDeleteEmailMessageHistory(IUnitOfWork unitOfWork, EmailMessageHistory @emailMessageHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessageHistory == null)
				throw new ArgumentNullException("@emailMessageHistory");

			// do nothing
		}

		partial void OnPostDeleteEmailMessageHistory(IUnitOfWork unitOfWork, EmailMessageHistory @emailMessageHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessageHistory == null)
				throw new ArgumentNullException("@emailMessageHistory");

			// do nothing
		}

		partial void OnSaveConflictEmailMessageHistory(IUnitOfWork unitOfWork, EmailMessageHistory @emailMessageHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessageHistory == null)
				throw new ArgumentNullException("@emailMessageHistory");

			// do nothing
		}

		partial void OnDiscardConflictEmailMessageHistory(IUnitOfWork unitOfWork, EmailMessageHistory @emailMessageHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessageHistory == null)
				throw new ArgumentNullException("@emailMessageHistory");

			// do nothing
		}

		partial void OnSelectEmailMessageHistory(IUnitOfWork unitOfWork, EmailMessageHistory @emailMessageHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailMessageHistory == null)
				throw new ArgumentNullException("@emailMessageHistory");

			// do nothing
		}


		partial void OnPreInsertEmailAttachmentHistory(IUnitOfWork unitOfWork, EmailAttachmentHistory @emailAttachmentHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachmentHistory == null)
				throw new ArgumentNullException("@emailAttachmentHistory");

			@emailAttachmentHistory.Mark();
		}

		partial void OnPostInsertEmailAttachmentHistory(IUnitOfWork unitOfWork, EmailAttachmentHistory @emailAttachmentHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachmentHistory == null)
				throw new ArgumentNullException("@emailAttachmentHistory");

			// do nothing
		}

		partial void OnPreUpdateEmailAttachmentHistory(IUnitOfWork unitOfWork, EmailAttachmentHistory @emailAttachmentHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachmentHistory == null)
				throw new ArgumentNullException("@emailAttachmentHistory");

			@emailAttachmentHistory.Mark();
		}

		partial void OnPostUpdateEmailAttachmentHistory(IUnitOfWork unitOfWork, EmailAttachmentHistory @emailAttachmentHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachmentHistory == null)
				throw new ArgumentNullException("@emailAttachmentHistory");

			// do nothing
		}

		partial void OnPreDeleteEmailAttachmentHistory(IUnitOfWork unitOfWork, EmailAttachmentHistory @emailAttachmentHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachmentHistory == null)
				throw new ArgumentNullException("@emailAttachmentHistory");

			// do nothing
		}

		partial void OnPostDeleteEmailAttachmentHistory(IUnitOfWork unitOfWork, EmailAttachmentHistory @emailAttachmentHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachmentHistory == null)
				throw new ArgumentNullException("@emailAttachmentHistory");

			// do nothing
		}

		partial void OnSaveConflictEmailAttachmentHistory(IUnitOfWork unitOfWork, EmailAttachmentHistory @emailAttachmentHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachmentHistory == null)
				throw new ArgumentNullException("@emailAttachmentHistory");

			// do nothing
		}

		partial void OnDiscardConflictEmailAttachmentHistory(IUnitOfWork unitOfWork, EmailAttachmentHistory @emailAttachmentHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachmentHistory == null)
				throw new ArgumentNullException("@emailAttachmentHistory");

			// do nothing
		}

		partial void OnSelectEmailAttachmentHistory(IUnitOfWork unitOfWork, EmailAttachmentHistory @emailAttachmentHistory)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@emailAttachmentHistory == null)
				throw new ArgumentNullException("@emailAttachmentHistory");

			// do nothing
		}

		partial void OnPreInsertTabWithPrimaryKeyAsIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsIdentity @tabWithPrimaryKeyAsIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsIdentity");

			@tabWithPrimaryKeyAsIdentity.Mark();
		}

		partial void OnPostInsertTabWithPrimaryKeyAsIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsIdentity @tabWithPrimaryKeyAsIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsIdentity");

			// do nothing
		}

		partial void OnPreUpdateTabWithPrimaryKeyAsIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsIdentity @tabWithPrimaryKeyAsIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsIdentity");

			@tabWithPrimaryKeyAsIdentity.Mark();
		}

		partial void OnPostUpdateTabWithPrimaryKeyAsIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsIdentity @tabWithPrimaryKeyAsIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsIdentity");

			// do nothing
		}

		partial void OnPreDeleteTabWithPrimaryKeyAsIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsIdentity @tabWithPrimaryKeyAsIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsIdentity");

			// do nothing
		}

		partial void OnPostDeleteTabWithPrimaryKeyAsIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsIdentity @tabWithPrimaryKeyAsIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsIdentity");

			// do nothing
		}

		partial void OnSaveConflictTabWithPrimaryKeyAsIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsIdentity @tabWithPrimaryKeyAsIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsIdentity");

			// do nothing
		}

		partial void OnDiscardConflictTabWithPrimaryKeyAsIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsIdentity @tabWithPrimaryKeyAsIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsIdentity");

			// do nothing
		}

		partial void OnSelectTabWithPrimaryKeyAsIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsIdentity @tabWithPrimaryKeyAsIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsIdentity");

			// do nothing
		}


		partial void OnPreInsertTabWithPrimaryKeyAsDefault(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsDefault @tabWithPrimaryKeyAsDefault)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsDefault == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsDefault");

			@tabWithPrimaryKeyAsDefault.Mark();
		}

		partial void OnPostInsertTabWithPrimaryKeyAsDefault(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsDefault @tabWithPrimaryKeyAsDefault)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsDefault == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsDefault");

			// do nothing
		}

		partial void OnPreUpdateTabWithPrimaryKeyAsDefault(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsDefault @tabWithPrimaryKeyAsDefault)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsDefault == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsDefault");

			@tabWithPrimaryKeyAsDefault.Mark();
		}

		partial void OnPostUpdateTabWithPrimaryKeyAsDefault(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsDefault @tabWithPrimaryKeyAsDefault)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsDefault == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsDefault");

			// do nothing
		}

		partial void OnPreDeleteTabWithPrimaryKeyAsDefault(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsDefault @tabWithPrimaryKeyAsDefault)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsDefault == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsDefault");

			// do nothing
		}

		partial void OnPostDeleteTabWithPrimaryKeyAsDefault(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsDefault @tabWithPrimaryKeyAsDefault)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsDefault == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsDefault");

			// do nothing
		}

		partial void OnSaveConflictTabWithPrimaryKeyAsDefault(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsDefault @tabWithPrimaryKeyAsDefault)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsDefault == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsDefault");

			// do nothing
		}

		partial void OnDiscardConflictTabWithPrimaryKeyAsDefault(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsDefault @tabWithPrimaryKeyAsDefault)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsDefault == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsDefault");

			// do nothing
		}

		partial void OnSelectTabWithPrimaryKeyAsDefault(IUnitOfWork unitOfWork, TabWithPrimaryKeyAsDefault @tabWithPrimaryKeyAsDefault)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyAsDefault == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyAsDefault");

			// do nothing
		}


		partial void OnPreInsertTabWithPrimaryKeyWithDifferentIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyWithDifferentIdentity @tabWithPrimaryKeyWithDifferentIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyWithDifferentIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyWithDifferentIdentity");

			@tabWithPrimaryKeyWithDifferentIdentity.Mark();
		}

		partial void OnPostInsertTabWithPrimaryKeyWithDifferentIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyWithDifferentIdentity @tabWithPrimaryKeyWithDifferentIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyWithDifferentIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyWithDifferentIdentity");

			// do nothing
		}

		partial void OnPreUpdateTabWithPrimaryKeyWithDifferentIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyWithDifferentIdentity @tabWithPrimaryKeyWithDifferentIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyWithDifferentIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyWithDifferentIdentity");

			@tabWithPrimaryKeyWithDifferentIdentity.Mark();
		}

		partial void OnPostUpdateTabWithPrimaryKeyWithDifferentIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyWithDifferentIdentity @tabWithPrimaryKeyWithDifferentIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyWithDifferentIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyWithDifferentIdentity");

			// do nothing
		}

		partial void OnPreDeleteTabWithPrimaryKeyWithDifferentIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyWithDifferentIdentity @tabWithPrimaryKeyWithDifferentIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyWithDifferentIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyWithDifferentIdentity");

			// do nothing
		}

		partial void OnPostDeleteTabWithPrimaryKeyWithDifferentIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyWithDifferentIdentity @tabWithPrimaryKeyWithDifferentIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyWithDifferentIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyWithDifferentIdentity");

			// do nothing
		}

		partial void OnSaveConflictTabWithPrimaryKeyWithDifferentIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyWithDifferentIdentity @tabWithPrimaryKeyWithDifferentIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyWithDifferentIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyWithDifferentIdentity");

			// do nothing
		}

		partial void OnDiscardConflictTabWithPrimaryKeyWithDifferentIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyWithDifferentIdentity @tabWithPrimaryKeyWithDifferentIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyWithDifferentIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyWithDifferentIdentity");

			// do nothing
		}

		partial void OnSelectTabWithPrimaryKeyWithDifferentIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyWithDifferentIdentity @tabWithPrimaryKeyWithDifferentIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyWithDifferentIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyWithDifferentIdentity");

			// do nothing
		}


		partial void OnPreInsertTabWithNoPrimaryKeyWithIdentity(IUnitOfWork unitOfWork, TabWithNoPrimaryKeyWithIdentity @tabWithNoPrimaryKeyWithIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithNoPrimaryKeyWithIdentity == null)
				throw new ArgumentNullException("@tabWithNoPrimaryKeyWithIdentity");

			@tabWithNoPrimaryKeyWithIdentity.Mark();
		}

		partial void OnPostInsertTabWithNoPrimaryKeyWithIdentity(IUnitOfWork unitOfWork, TabWithNoPrimaryKeyWithIdentity @tabWithNoPrimaryKeyWithIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithNoPrimaryKeyWithIdentity == null)
				throw new ArgumentNullException("@tabWithNoPrimaryKeyWithIdentity");

			// do nothing
		}

		partial void OnPreUpdateTabWithNoPrimaryKeyWithIdentity(IUnitOfWork unitOfWork, TabWithNoPrimaryKeyWithIdentity @tabWithNoPrimaryKeyWithIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithNoPrimaryKeyWithIdentity == null)
				throw new ArgumentNullException("@tabWithNoPrimaryKeyWithIdentity");

			@tabWithNoPrimaryKeyWithIdentity.Mark();
		}

		partial void OnPostUpdateTabWithNoPrimaryKeyWithIdentity(IUnitOfWork unitOfWork, TabWithNoPrimaryKeyWithIdentity @tabWithNoPrimaryKeyWithIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithNoPrimaryKeyWithIdentity == null)
				throw new ArgumentNullException("@tabWithNoPrimaryKeyWithIdentity");

			// do nothing
		}

		partial void OnPreDeleteTabWithNoPrimaryKeyWithIdentity(IUnitOfWork unitOfWork, TabWithNoPrimaryKeyWithIdentity @tabWithNoPrimaryKeyWithIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithNoPrimaryKeyWithIdentity == null)
				throw new ArgumentNullException("@tabWithNoPrimaryKeyWithIdentity");

			// do nothing
		}

		partial void OnPostDeleteTabWithNoPrimaryKeyWithIdentity(IUnitOfWork unitOfWork, TabWithNoPrimaryKeyWithIdentity @tabWithNoPrimaryKeyWithIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithNoPrimaryKeyWithIdentity == null)
				throw new ArgumentNullException("@tabWithNoPrimaryKeyWithIdentity");

			// do nothing
		}

		partial void OnSaveConflictTabWithNoPrimaryKeyWithIdentity(IUnitOfWork unitOfWork, TabWithNoPrimaryKeyWithIdentity @tabWithNoPrimaryKeyWithIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithNoPrimaryKeyWithIdentity == null)
				throw new ArgumentNullException("@tabWithNoPrimaryKeyWithIdentity");

			// do nothing
		}

		partial void OnDiscardConflictTabWithNoPrimaryKeyWithIdentity(IUnitOfWork unitOfWork, TabWithNoPrimaryKeyWithIdentity @tabWithNoPrimaryKeyWithIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithNoPrimaryKeyWithIdentity == null)
				throw new ArgumentNullException("@tabWithNoPrimaryKeyWithIdentity");

			// do nothing
		}

		partial void OnSelectTabWithNoPrimaryKeyWithIdentity(IUnitOfWork unitOfWork, TabWithNoPrimaryKeyWithIdentity @tabWithNoPrimaryKeyWithIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithNoPrimaryKeyWithIdentity == null)
				throw new ArgumentNullException("@tabWithNoPrimaryKeyWithIdentity");

			// do nothing
		}


		partial void OnPreInsertTabWithPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyNoIdentity @tabWithPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyNoIdentity");

			@tabWithPrimaryKeyNoIdentity.Mark();
		}

		partial void OnPostInsertTabWithPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyNoIdentity @tabWithPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnPreUpdateTabWithPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyNoIdentity @tabWithPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyNoIdentity");

			@tabWithPrimaryKeyNoIdentity.Mark();
		}

		partial void OnPostUpdateTabWithPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyNoIdentity @tabWithPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnPreDeleteTabWithPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyNoIdentity @tabWithPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnPostDeleteTabWithPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyNoIdentity @tabWithPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnSaveConflictTabWithPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyNoIdentity @tabWithPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnDiscardConflictTabWithPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyNoIdentity @tabWithPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnSelectTabWithPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithPrimaryKeyNoIdentity @tabWithPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithPrimaryKeyNoIdentity");

			// do nothing
		}


		partial void OnPreInsertTabNoPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabNoPrimaryKeyNoIdentity @tabNoPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabNoPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabNoPrimaryKeyNoIdentity");

			@tabNoPrimaryKeyNoIdentity.Mark();
		}

		partial void OnPostInsertTabNoPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabNoPrimaryKeyNoIdentity @tabNoPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabNoPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabNoPrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnPreUpdateTabNoPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabNoPrimaryKeyNoIdentity @tabNoPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabNoPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabNoPrimaryKeyNoIdentity");

			@tabNoPrimaryKeyNoIdentity.Mark();
		}

		partial void OnPostUpdateTabNoPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabNoPrimaryKeyNoIdentity @tabNoPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabNoPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabNoPrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnPreDeleteTabNoPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabNoPrimaryKeyNoIdentity @tabNoPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabNoPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabNoPrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnPostDeleteTabNoPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabNoPrimaryKeyNoIdentity @tabNoPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabNoPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabNoPrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnSaveConflictTabNoPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabNoPrimaryKeyNoIdentity @tabNoPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabNoPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabNoPrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnDiscardConflictTabNoPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabNoPrimaryKeyNoIdentity @tabNoPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabNoPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabNoPrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnSelectTabNoPrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabNoPrimaryKeyNoIdentity @tabNoPrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabNoPrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabNoPrimaryKeyNoIdentity");

			// do nothing
		}


		partial void OnPreInsertTabWithCompositePrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithCompositePrimaryKeyNoIdentity @tabWithCompositePrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithCompositePrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithCompositePrimaryKeyNoIdentity");

			@tabWithCompositePrimaryKeyNoIdentity.Mark();
		}

		partial void OnPostInsertTabWithCompositePrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithCompositePrimaryKeyNoIdentity @tabWithCompositePrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithCompositePrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithCompositePrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnPreUpdateTabWithCompositePrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithCompositePrimaryKeyNoIdentity @tabWithCompositePrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithCompositePrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithCompositePrimaryKeyNoIdentity");

			@tabWithCompositePrimaryKeyNoIdentity.Mark();
		}

		partial void OnPostUpdateTabWithCompositePrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithCompositePrimaryKeyNoIdentity @tabWithCompositePrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithCompositePrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithCompositePrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnPreDeleteTabWithCompositePrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithCompositePrimaryKeyNoIdentity @tabWithCompositePrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithCompositePrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithCompositePrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnPostDeleteTabWithCompositePrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithCompositePrimaryKeyNoIdentity @tabWithCompositePrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithCompositePrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithCompositePrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnSaveConflictTabWithCompositePrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithCompositePrimaryKeyNoIdentity @tabWithCompositePrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithCompositePrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithCompositePrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnDiscardConflictTabWithCompositePrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithCompositePrimaryKeyNoIdentity @tabWithCompositePrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithCompositePrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithCompositePrimaryKeyNoIdentity");

			// do nothing
		}

		partial void OnSelectTabWithCompositePrimaryKeyNoIdentity(IUnitOfWork unitOfWork, TabWithCompositePrimaryKeyNoIdentity @tabWithCompositePrimaryKeyNoIdentity)
		{
			if ((object)unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			if ((object)@tabWithCompositePrimaryKeyNoIdentity == null)
				throw new ArgumentNullException("@tabWithCompositePrimaryKeyNoIdentity");

			// do nothing
		}

		public bool TrySendEmailTemplate(string templateResourceName, object modelObject)
		{
			Type templateResourceType;
			MessageTemplate messageTemplate;
			EmailMessage emailMessage;
			EmailAttachment emailAttachment;

			if ((object)templateResourceName == null)
				throw new ArgumentNullException("templateResourceName");

			if ((object)modelObject == null)
				throw new ArgumentNullException("modelObject");

			try
			{
				templateResourceType = typeof(Repository);
				if (!Cerealization.TryGetFromAssemblyResource<MessageTemplate>(templateResourceType, templateResourceName, out messageTemplate))
					throw new InvalidOperationException(string.Format("Unable to deserialize instance of '{0}' from the manifest resource name '{1}' in the assembly '{2}'.", typeof(MessageTemplate).FullName, templateResourceName, templateResourceType.Assembly.FullName));

				emailMessage = new EmailMessage();
				/*emailAttachment = new EmailAttachment();
				emailAttachment.FileName = "data.txt";
				emailAttachment.MimeType = "text/plain";
				emailAttachment.AttachmentBits = Encoding.UTF8.GetBytes("some sample data");

				emailMessage.EmailAttachments.Add(emailAttachment);*/

				try
				{
					new EmailHost().Host(true, messageTemplate, modelObject, emailMessage);
				}
				finally
				{
					this.SaveEmailMessage(emailMessage);
				}

				return true;
			}
			catch (Exception ex)
			{
				// swallow intentionally
				this.TryWriteEventLogEntry(Reflexion.GetErrors(ex, 0));
				return false;
			}
		}

		public bool TryWriteEventLogEntry(string eventText)
		{
			EventLog eventLog;
			bool result;

			if ((object)eventText == null)
				throw new ArgumentNullException("eventText");

			try
			{
				eventLog = new EventLog();
				eventLog.EventText = eventText;

				result = this.SaveEventLog(eventLog);
				return result;
			}
			catch (Exception ex)
			{
				// swallow intentionally
				return false;
			}
		}

		#endregion
	}
}
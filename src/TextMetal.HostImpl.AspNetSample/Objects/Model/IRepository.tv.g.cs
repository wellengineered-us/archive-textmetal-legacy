﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by:
// TextMetal 5.0.3.40772;
// 		Copyright ©2002-2013 Daniel Bullington (dpbullington@gmail.com)
//		Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
//		Project URL: https://github.com/dpbullington/textmetal
//
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//
// </auto-generated>
//------------------------------------------------------------------------------

/*
	Copyright ©2002-2013 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Xml;

using TextMetal.Common.Core;
using TextMetal.Common.Data;
using TextMetal.Common.Data.LinqToSql;

using TextMetal.HostImpl.AspNetSample.Objects.Model.Tables;
using TextMetal.HostImpl.AspNetSample.Objects.Model.Views;

namespace TextMetal.HostImpl.AspNetSample.Objects.Model
{
	public partial interface IRepository
	{		
		#region Methods/Operators
		
		EventLog LoadEventLog(Int32 @eventLogId);

		EventLog LoadEventLog(IUnitOfWorkContext unitOfWorkContext, Int32 @eventLogId);
						
		IList<EventLog> FindEventLogs(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EventLog>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EventLog>> callback);
		
		IList<EventLog> FindEventLogs(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EventLog>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EventLog>> callback);
		
		bool SaveEventLog(EventLog @eventLog);
		
		bool SaveEventLog(IUnitOfWorkContext unitOfWorkContext, EventLog @eventLog);
		
		bool DiscardEventLog(EventLog @eventLog);
		
		bool DiscardEventLog(IUnitOfWorkContext unitOfWorkContext, EventLog @eventLog);

		EmailMessage LoadEmailMessage(Int32 @emailMessageId);

		EmailMessage LoadEmailMessage(IUnitOfWorkContext unitOfWorkContext, Int32 @emailMessageId);
						
		IList<EmailMessage> FindEmailMessages(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailMessage>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailMessage>> callback);
		
		IList<EmailMessage> FindEmailMessages(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailMessage>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailMessage>> callback);
		
		bool SaveEmailMessage(EmailMessage @emailMessage);
		
		bool SaveEmailMessage(IUnitOfWorkContext unitOfWorkContext, EmailMessage @emailMessage);
		
		bool DiscardEmailMessage(EmailMessage @emailMessage);
		
		bool DiscardEmailMessage(IUnitOfWorkContext unitOfWorkContext, EmailMessage @emailMessage);

		EmailAttachment LoadEmailAttachment(Int32 @emailAttachmentId);

		EmailAttachment LoadEmailAttachment(IUnitOfWorkContext unitOfWorkContext, Int32 @emailAttachmentId);
						
		IList<EmailAttachment> FindEmailAttachments(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailAttachment>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailAttachment>> callback);
		
		IList<EmailAttachment> FindEmailAttachments(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailAttachment>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailAttachment>> callback);
		
		bool SaveEmailAttachment(EmailAttachment @emailAttachment);
		
		bool SaveEmailAttachment(IUnitOfWorkContext unitOfWorkContext, EmailAttachment @emailAttachment);
		
		bool DiscardEmailAttachment(EmailAttachment @emailAttachment);
		
		bool DiscardEmailAttachment(IUnitOfWorkContext unitOfWorkContext, EmailAttachment @emailAttachment);

		TableWithPrimaryKeyAsIdentity LoadTableWithPrimaryKeyAsIdentity(Int32 @pkId);

		TableWithPrimaryKeyAsIdentity LoadTableWithPrimaryKeyAsIdentity(IUnitOfWorkContext unitOfWorkContext, Int32 @pkId);
						
		IList<TableWithPrimaryKeyAsIdentity> FindTableWithPrimaryKeyAsIdentities(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsIdentity>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsIdentity>> callback);
		
		IList<TableWithPrimaryKeyAsIdentity> FindTableWithPrimaryKeyAsIdentities(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsIdentity>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsIdentity>> callback);
		
		bool SaveTableWithPrimaryKeyAsIdentity(TableWithPrimaryKeyAsIdentity @tableWithPrimaryKeyAsIdentity);
		
		bool SaveTableWithPrimaryKeyAsIdentity(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyAsIdentity @tableWithPrimaryKeyAsIdentity);
		
		bool DiscardTableWithPrimaryKeyAsIdentity(TableWithPrimaryKeyAsIdentity @tableWithPrimaryKeyAsIdentity);
		
		bool DiscardTableWithPrimaryKeyAsIdentity(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyAsIdentity @tableWithPrimaryKeyAsIdentity);

		TableWithPrimaryKeyAsDefault LoadTableWithPrimaryKeyAsDefault(Guid @pkDf);

		TableWithPrimaryKeyAsDefault LoadTableWithPrimaryKeyAsDefault(IUnitOfWorkContext unitOfWorkContext, Guid @pkDf);
						
		IList<TableWithPrimaryKeyAsDefault> FindTableWithPrimaryKeyAsDefaults(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsDefault>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsDefault>> callback);
		
		IList<TableWithPrimaryKeyAsDefault> FindTableWithPrimaryKeyAsDefaults(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsDefault>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsDefault>> callback);
		
		bool SaveTableWithPrimaryKeyAsDefault(TableWithPrimaryKeyAsDefault @tableWithPrimaryKeyAsDefault);
		
		bool SaveTableWithPrimaryKeyAsDefault(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyAsDefault @tableWithPrimaryKeyAsDefault);
		
		bool DiscardTableWithPrimaryKeyAsDefault(TableWithPrimaryKeyAsDefault @tableWithPrimaryKeyAsDefault);
		
		bool DiscardTableWithPrimaryKeyAsDefault(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyAsDefault @tableWithPrimaryKeyAsDefault);

		TableWithPrimaryKeyWithDiffIdentity LoadTableWithPrimaryKeyWithDiffIdentity(Int32 @pk);

		TableWithPrimaryKeyWithDiffIdentity LoadTableWithPrimaryKeyWithDiffIdentity(IUnitOfWorkContext unitOfWorkContext, Int32 @pk);
						
		IList<TableWithPrimaryKeyWithDiffIdentity> FindTableWithPrimaryKeyWithDiffIdentities(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyWithDiffIdentity>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyWithDiffIdentity>> callback);
		
		IList<TableWithPrimaryKeyWithDiffIdentity> FindTableWithPrimaryKeyWithDiffIdentities(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyWithDiffIdentity>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyWithDiffIdentity>> callback);
		
		bool SaveTableWithPrimaryKeyWithDiffIdentity(TableWithPrimaryKeyWithDiffIdentity @tableWithPrimaryKeyWithDiffIdentity);
		
		bool SaveTableWithPrimaryKeyWithDiffIdentity(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyWithDiffIdentity @tableWithPrimaryKeyWithDiffIdentity);
		
		bool DiscardTableWithPrimaryKeyWithDiffIdentity(TableWithPrimaryKeyWithDiffIdentity @tableWithPrimaryKeyWithDiffIdentity);
		
		bool DiscardTableWithPrimaryKeyWithDiffIdentity(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyWithDiffIdentity @tableWithPrimaryKeyWithDiffIdentity);

		TableNoPrimaryKeyWithIdentity LoadTableNoPrimaryKeyWithIdentity(Int32 @id, Boolean @data01, DateTime @data02, Int32 @data03, String @data04);

		TableNoPrimaryKeyWithIdentity LoadTableNoPrimaryKeyWithIdentity(IUnitOfWorkContext unitOfWorkContext, Int32 @id, Boolean @data01, DateTime @data02, Int32 @data03, String @data04);
						
		IList<TableNoPrimaryKeyWithIdentity> FindTableNoPrimaryKeyWithIdentities(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyWithIdentity>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyWithIdentity>> callback);
		
		IList<TableNoPrimaryKeyWithIdentity> FindTableNoPrimaryKeyWithIdentities(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyWithIdentity>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyWithIdentity>> callback);
		
		bool SaveTableNoPrimaryKeyWithIdentity(TableNoPrimaryKeyWithIdentity @tableNoPrimaryKeyWithIdentity);
		
		bool SaveTableNoPrimaryKeyWithIdentity(IUnitOfWorkContext unitOfWorkContext, TableNoPrimaryKeyWithIdentity @tableNoPrimaryKeyWithIdentity);
		
		bool DiscardTableNoPrimaryKeyWithIdentity(TableNoPrimaryKeyWithIdentity @tableNoPrimaryKeyWithIdentity);
		
		bool DiscardTableNoPrimaryKeyWithIdentity(IUnitOfWorkContext unitOfWorkContext, TableNoPrimaryKeyWithIdentity @tableNoPrimaryKeyWithIdentity);

		TableWithPrimaryKeyNoIdentity LoadTableWithPrimaryKeyNoIdentity(Int32 @pk);

		TableWithPrimaryKeyNoIdentity LoadTableWithPrimaryKeyNoIdentity(IUnitOfWorkContext unitOfWorkContext, Int32 @pk);
						
		IList<TableWithPrimaryKeyNoIdentity> FindTableWithPrimaryKeyNoIdentities(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyNoIdentity>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyNoIdentity>> callback);
		
		IList<TableWithPrimaryKeyNoIdentity> FindTableWithPrimaryKeyNoIdentities(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyNoIdentity>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyNoIdentity>> callback);
		
		bool SaveTableWithPrimaryKeyNoIdentity(TableWithPrimaryKeyNoIdentity @tableWithPrimaryKeyNoIdentity);
		
		bool SaveTableWithPrimaryKeyNoIdentity(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyNoIdentity @tableWithPrimaryKeyNoIdentity);
		
		bool DiscardTableWithPrimaryKeyNoIdentity(TableWithPrimaryKeyNoIdentity @tableWithPrimaryKeyNoIdentity);
		
		bool DiscardTableWithPrimaryKeyNoIdentity(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyNoIdentity @tableWithPrimaryKeyNoIdentity);

		TableWithCompositePrimaryKeyNoIdentity LoadTableWithCompositePrimaryKeyNoIdentity(Int32 @pk0, Int32 @pk1, Int32 @pk2, Int32 @pk3);

		TableWithCompositePrimaryKeyNoIdentity LoadTableWithCompositePrimaryKeyNoIdentity(IUnitOfWorkContext unitOfWorkContext, Int32 @pk0, Int32 @pk1, Int32 @pk2, Int32 @pk3);
						
		IList<TableWithCompositePrimaryKeyNoIdentity> FindTableWithCompositePrimaryKeyNoIdentities(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithCompositePrimaryKeyNoIdentity>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithCompositePrimaryKeyNoIdentity>> callback);
		
		IList<TableWithCompositePrimaryKeyNoIdentity> FindTableWithCompositePrimaryKeyNoIdentities(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithCompositePrimaryKeyNoIdentity>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithCompositePrimaryKeyNoIdentity>> callback);
		
		bool SaveTableWithCompositePrimaryKeyNoIdentity(TableWithCompositePrimaryKeyNoIdentity @tableWithCompositePrimaryKeyNoIdentity);
		
		bool SaveTableWithCompositePrimaryKeyNoIdentity(IUnitOfWorkContext unitOfWorkContext, TableWithCompositePrimaryKeyNoIdentity @tableWithCompositePrimaryKeyNoIdentity);
		
		bool DiscardTableWithCompositePrimaryKeyNoIdentity(TableWithCompositePrimaryKeyNoIdentity @tableWithCompositePrimaryKeyNoIdentity);
		
		bool DiscardTableWithCompositePrimaryKeyNoIdentity(IUnitOfWorkContext unitOfWorkContext, TableWithCompositePrimaryKeyNoIdentity @tableWithCompositePrimaryKeyNoIdentity);

		TableNoPrimaryKeyNoIdentity LoadTableNoPrimaryKeyNoIdentity(Int32 @value, Boolean @data01, DateTime @data02, Int32 @data03, String @data04);

		TableNoPrimaryKeyNoIdentity LoadTableNoPrimaryKeyNoIdentity(IUnitOfWorkContext unitOfWorkContext, Int32 @value, Boolean @data01, DateTime @data02, Int32 @data03, String @data04);
						
		IList<TableNoPrimaryKeyNoIdentity> FindTableNoPrimaryKeyNoIdentities(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyNoIdentity>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyNoIdentity>> callback);
		
		IList<TableNoPrimaryKeyNoIdentity> FindTableNoPrimaryKeyNoIdentities(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyNoIdentity>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyNoIdentity>> callback);
		
		bool SaveTableNoPrimaryKeyNoIdentity(TableNoPrimaryKeyNoIdentity @tableNoPrimaryKeyNoIdentity);
		
		bool SaveTableNoPrimaryKeyNoIdentity(IUnitOfWorkContext unitOfWorkContext, TableNoPrimaryKeyNoIdentity @tableNoPrimaryKeyNoIdentity);
		
		bool DiscardTableNoPrimaryKeyNoIdentity(TableNoPrimaryKeyNoIdentity @tableNoPrimaryKeyNoIdentity);
		
		bool DiscardTableNoPrimaryKeyNoIdentity(IUnitOfWorkContext unitOfWorkContext, TableNoPrimaryKeyNoIdentity @tableNoPrimaryKeyNoIdentity);

		TableTypeTest LoadTableTypeTest(Int32 @pkId);

		TableTypeTest LoadTableTypeTest(IUnitOfWorkContext unitOfWorkContext, Int32 @pkId);
						
		IList<TableTypeTest> FindTableTypeTests(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableTypeTest>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableTypeTest>> callback);
		
		IList<TableTypeTest> FindTableTypeTests(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableTypeTest>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableTypeTest>> callback);
		
		bool SaveTableTypeTest(TableTypeTest @tableTypeTest);
		
		bool SaveTableTypeTest(IUnitOfWorkContext unitOfWorkContext, TableTypeTest @tableTypeTest);
		
		bool DiscardTableTypeTest(TableTypeTest @tableTypeTest);
		
		bool DiscardTableTypeTest(IUnitOfWorkContext unitOfWorkContext, TableTypeTest @tableTypeTest);

		EventLogAggregation LoadEventLogAggregation(DateTime @minCreationTimestamp, DateTime @maxModificationTimestamp);

		EventLogAggregation LoadEventLogAggregation(IUnitOfWorkContext unitOfWorkContext, DateTime @minCreationTimestamp, DateTime @maxModificationTimestamp);
						
		IList<EventLogAggregation> FindEventLogAggregations(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EventLogAggregation>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EventLogAggregation>> callback);
		
		IList<EventLogAggregation> FindEventLogAggregations(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EventLogAggregation>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EventLogAggregation>> callback);
		
		bool SaveEventLogAggregation(EventLogAggregation @eventLogAggregation);
		
		bool SaveEventLogAggregation(IUnitOfWorkContext unitOfWorkContext, EventLogAggregation @eventLogAggregation);
		
		bool DiscardEventLogAggregation(EventLogAggregation @eventLogAggregation);
		
		bool DiscardEventLogAggregation(IUnitOfWorkContext unitOfWorkContext, EventLogAggregation @eventLogAggregation);
		EventLogHistory LoadEventLogHistory(Int64 @timestampId, Int32 @eventLogId);

		EventLogHistory LoadEventLogHistory(IUnitOfWorkContext unitOfWorkContext, Int64 @timestampId, Int32 @eventLogId);
						
		IList<EventLogHistory> FindEventLogHistories(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EventLogHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EventLogHistory>> callback);
		
		IList<EventLogHistory> FindEventLogHistories(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EventLogHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EventLogHistory>> callback);
		
		bool SaveEventLogHistory(EventLogHistory @eventLogHistory);
		
		bool SaveEventLogHistory(IUnitOfWorkContext unitOfWorkContext, EventLogHistory @eventLogHistory);
		
		bool DiscardEventLogHistory(EventLogHistory @eventLogHistory);
		
		bool DiscardEventLogHistory(IUnitOfWorkContext unitOfWorkContext, EventLogHistory @eventLogHistory);

		EmailMessageHistory LoadEmailMessageHistory(Int64 @timestampId, Int32 @emailMessageId);

		EmailMessageHistory LoadEmailMessageHistory(IUnitOfWorkContext unitOfWorkContext, Int64 @timestampId, Int32 @emailMessageId);
						
		IList<EmailMessageHistory> FindEmailMessageHistories(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailMessageHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailMessageHistory>> callback);
		
		IList<EmailMessageHistory> FindEmailMessageHistories(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailMessageHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailMessageHistory>> callback);
		
		bool SaveEmailMessageHistory(EmailMessageHistory @emailMessageHistory);
		
		bool SaveEmailMessageHistory(IUnitOfWorkContext unitOfWorkContext, EmailMessageHistory @emailMessageHistory);
		
		bool DiscardEmailMessageHistory(EmailMessageHistory @emailMessageHistory);
		
		bool DiscardEmailMessageHistory(IUnitOfWorkContext unitOfWorkContext, EmailMessageHistory @emailMessageHistory);

		EmailAttachmentHistory LoadEmailAttachmentHistory(Int64 @timestampId, Int32 @emailAttachmentId);

		EmailAttachmentHistory LoadEmailAttachmentHistory(IUnitOfWorkContext unitOfWorkContext, Int64 @timestampId, Int32 @emailAttachmentId);
						
		IList<EmailAttachmentHistory> FindEmailAttachmentHistories(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailAttachmentHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailAttachmentHistory>> callback);
		
		IList<EmailAttachmentHistory> FindEmailAttachmentHistories(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailAttachmentHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.EmailAttachmentHistory>> callback);
		
		bool SaveEmailAttachmentHistory(EmailAttachmentHistory @emailAttachmentHistory);
		
		bool SaveEmailAttachmentHistory(IUnitOfWorkContext unitOfWorkContext, EmailAttachmentHistory @emailAttachmentHistory);
		
		bool DiscardEmailAttachmentHistory(EmailAttachmentHistory @emailAttachmentHistory);
		
		bool DiscardEmailAttachmentHistory(IUnitOfWorkContext unitOfWorkContext, EmailAttachmentHistory @emailAttachmentHistory);

		TableWithPrimaryKeyAsIdentityHistory LoadTableWithPrimaryKeyAsIdentityHistory(Int64 @timestampId, Int32 @pkId);

		TableWithPrimaryKeyAsIdentityHistory LoadTableWithPrimaryKeyAsIdentityHistory(IUnitOfWorkContext unitOfWorkContext, Int64 @timestampId, Int32 @pkId);
						
		IList<TableWithPrimaryKeyAsIdentityHistory> FindTableWithPrimaryKeyAsIdentityHistories(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsIdentityHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsIdentityHistory>> callback);
		
		IList<TableWithPrimaryKeyAsIdentityHistory> FindTableWithPrimaryKeyAsIdentityHistories(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsIdentityHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsIdentityHistory>> callback);
		
		bool SaveTableWithPrimaryKeyAsIdentityHistory(TableWithPrimaryKeyAsIdentityHistory @tableWithPrimaryKeyAsIdentityHistory);
		
		bool SaveTableWithPrimaryKeyAsIdentityHistory(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyAsIdentityHistory @tableWithPrimaryKeyAsIdentityHistory);
		
		bool DiscardTableWithPrimaryKeyAsIdentityHistory(TableWithPrimaryKeyAsIdentityHistory @tableWithPrimaryKeyAsIdentityHistory);
		
		bool DiscardTableWithPrimaryKeyAsIdentityHistory(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyAsIdentityHistory @tableWithPrimaryKeyAsIdentityHistory);

		TableWithPrimaryKeyAsDefaultHistory LoadTableWithPrimaryKeyAsDefaultHistory(Int64 @timestampId, Guid @pkDf);

		TableWithPrimaryKeyAsDefaultHistory LoadTableWithPrimaryKeyAsDefaultHistory(IUnitOfWorkContext unitOfWorkContext, Int64 @timestampId, Guid @pkDf);
						
		IList<TableWithPrimaryKeyAsDefaultHistory> FindTableWithPrimaryKeyAsDefaultHistories(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsDefaultHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsDefaultHistory>> callback);
		
		IList<TableWithPrimaryKeyAsDefaultHistory> FindTableWithPrimaryKeyAsDefaultHistories(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsDefaultHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyAsDefaultHistory>> callback);
		
		bool SaveTableWithPrimaryKeyAsDefaultHistory(TableWithPrimaryKeyAsDefaultHistory @tableWithPrimaryKeyAsDefaultHistory);
		
		bool SaveTableWithPrimaryKeyAsDefaultHistory(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyAsDefaultHistory @tableWithPrimaryKeyAsDefaultHistory);
		
		bool DiscardTableWithPrimaryKeyAsDefaultHistory(TableWithPrimaryKeyAsDefaultHistory @tableWithPrimaryKeyAsDefaultHistory);
		
		bool DiscardTableWithPrimaryKeyAsDefaultHistory(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyAsDefaultHistory @tableWithPrimaryKeyAsDefaultHistory);

		TableWithPrimaryKeyWithDiffIdentityHistory LoadTableWithPrimaryKeyWithDiffIdentityHistory(Int64 @timestampId, Int32 @pk);

		TableWithPrimaryKeyWithDiffIdentityHistory LoadTableWithPrimaryKeyWithDiffIdentityHistory(IUnitOfWorkContext unitOfWorkContext, Int64 @timestampId, Int32 @pk);
						
		IList<TableWithPrimaryKeyWithDiffIdentityHistory> FindTableWithPrimaryKeyWithDiffIdentityHistories(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyWithDiffIdentityHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyWithDiffIdentityHistory>> callback);
		
		IList<TableWithPrimaryKeyWithDiffIdentityHistory> FindTableWithPrimaryKeyWithDiffIdentityHistories(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyWithDiffIdentityHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyWithDiffIdentityHistory>> callback);
		
		bool SaveTableWithPrimaryKeyWithDiffIdentityHistory(TableWithPrimaryKeyWithDiffIdentityHistory @tableWithPrimaryKeyWithDiffIdentityHistory);
		
		bool SaveTableWithPrimaryKeyWithDiffIdentityHistory(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyWithDiffIdentityHistory @tableWithPrimaryKeyWithDiffIdentityHistory);
		
		bool DiscardTableWithPrimaryKeyWithDiffIdentityHistory(TableWithPrimaryKeyWithDiffIdentityHistory @tableWithPrimaryKeyWithDiffIdentityHistory);
		
		bool DiscardTableWithPrimaryKeyWithDiffIdentityHistory(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyWithDiffIdentityHistory @tableWithPrimaryKeyWithDiffIdentityHistory);

		TableNoPrimaryKeyWithIdentityHistory LoadTableNoPrimaryKeyWithIdentityHistory(Int64 @timestampId, Int32 @id, Boolean @data01, DateTime @data02, Int32 @data03, String @data04);

		TableNoPrimaryKeyWithIdentityHistory LoadTableNoPrimaryKeyWithIdentityHistory(IUnitOfWorkContext unitOfWorkContext, Int64 @timestampId, Int32 @id, Boolean @data01, DateTime @data02, Int32 @data03, String @data04);
						
		IList<TableNoPrimaryKeyWithIdentityHistory> FindTableNoPrimaryKeyWithIdentityHistories(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyWithIdentityHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyWithIdentityHistory>> callback);
		
		IList<TableNoPrimaryKeyWithIdentityHistory> FindTableNoPrimaryKeyWithIdentityHistories(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyWithIdentityHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyWithIdentityHistory>> callback);
		
		bool SaveTableNoPrimaryKeyWithIdentityHistory(TableNoPrimaryKeyWithIdentityHistory @tableNoPrimaryKeyWithIdentityHistory);
		
		bool SaveTableNoPrimaryKeyWithIdentityHistory(IUnitOfWorkContext unitOfWorkContext, TableNoPrimaryKeyWithIdentityHistory @tableNoPrimaryKeyWithIdentityHistory);
		
		bool DiscardTableNoPrimaryKeyWithIdentityHistory(TableNoPrimaryKeyWithIdentityHistory @tableNoPrimaryKeyWithIdentityHistory);
		
		bool DiscardTableNoPrimaryKeyWithIdentityHistory(IUnitOfWorkContext unitOfWorkContext, TableNoPrimaryKeyWithIdentityHistory @tableNoPrimaryKeyWithIdentityHistory);

		TableWithPrimaryKeyNoIdentityHistory LoadTableWithPrimaryKeyNoIdentityHistory(Int64 @timestampId, Int32 @pk);

		TableWithPrimaryKeyNoIdentityHistory LoadTableWithPrimaryKeyNoIdentityHistory(IUnitOfWorkContext unitOfWorkContext, Int64 @timestampId, Int32 @pk);
						
		IList<TableWithPrimaryKeyNoIdentityHistory> FindTableWithPrimaryKeyNoIdentityHistories(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyNoIdentityHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyNoIdentityHistory>> callback);
		
		IList<TableWithPrimaryKeyNoIdentityHistory> FindTableWithPrimaryKeyNoIdentityHistories(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyNoIdentityHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithPrimaryKeyNoIdentityHistory>> callback);
		
		bool SaveTableWithPrimaryKeyNoIdentityHistory(TableWithPrimaryKeyNoIdentityHistory @tableWithPrimaryKeyNoIdentityHistory);
		
		bool SaveTableWithPrimaryKeyNoIdentityHistory(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyNoIdentityHistory @tableWithPrimaryKeyNoIdentityHistory);
		
		bool DiscardTableWithPrimaryKeyNoIdentityHistory(TableWithPrimaryKeyNoIdentityHistory @tableWithPrimaryKeyNoIdentityHistory);
		
		bool DiscardTableWithPrimaryKeyNoIdentityHistory(IUnitOfWorkContext unitOfWorkContext, TableWithPrimaryKeyNoIdentityHistory @tableWithPrimaryKeyNoIdentityHistory);

		TableWithCompositePrimaryKeyNoIdentityHistory LoadTableWithCompositePrimaryKeyNoIdentityHistory(Int64 @timestampId, Int32 @pk0, Int32 @pk1, Int32 @pk2, Int32 @pk3);

		TableWithCompositePrimaryKeyNoIdentityHistory LoadTableWithCompositePrimaryKeyNoIdentityHistory(IUnitOfWorkContext unitOfWorkContext, Int64 @timestampId, Int32 @pk0, Int32 @pk1, Int32 @pk2, Int32 @pk3);
						
		IList<TableWithCompositePrimaryKeyNoIdentityHistory> FindTableWithCompositePrimaryKeyNoIdentityHistories(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithCompositePrimaryKeyNoIdentityHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithCompositePrimaryKeyNoIdentityHistory>> callback);
		
		IList<TableWithCompositePrimaryKeyNoIdentityHistory> FindTableWithCompositePrimaryKeyNoIdentityHistories(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithCompositePrimaryKeyNoIdentityHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableWithCompositePrimaryKeyNoIdentityHistory>> callback);
		
		bool SaveTableWithCompositePrimaryKeyNoIdentityHistory(TableWithCompositePrimaryKeyNoIdentityHistory @tableWithCompositePrimaryKeyNoIdentityHistory);
		
		bool SaveTableWithCompositePrimaryKeyNoIdentityHistory(IUnitOfWorkContext unitOfWorkContext, TableWithCompositePrimaryKeyNoIdentityHistory @tableWithCompositePrimaryKeyNoIdentityHistory);
		
		bool DiscardTableWithCompositePrimaryKeyNoIdentityHistory(TableWithCompositePrimaryKeyNoIdentityHistory @tableWithCompositePrimaryKeyNoIdentityHistory);
		
		bool DiscardTableWithCompositePrimaryKeyNoIdentityHistory(IUnitOfWorkContext unitOfWorkContext, TableWithCompositePrimaryKeyNoIdentityHistory @tableWithCompositePrimaryKeyNoIdentityHistory);

		TableNoPrimaryKeyNoIdentityHistory LoadTableNoPrimaryKeyNoIdentityHistory(Int64 @timestampId, Int32 @value, Boolean @data01, DateTime @data02, Int32 @data03, String @data04);

		TableNoPrimaryKeyNoIdentityHistory LoadTableNoPrimaryKeyNoIdentityHistory(IUnitOfWorkContext unitOfWorkContext, Int64 @timestampId, Int32 @value, Boolean @data01, DateTime @data02, Int32 @data03, String @data04);
						
		IList<TableNoPrimaryKeyNoIdentityHistory> FindTableNoPrimaryKeyNoIdentityHistories(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyNoIdentityHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyNoIdentityHistory>> callback);
		
		IList<TableNoPrimaryKeyNoIdentityHistory> FindTableNoPrimaryKeyNoIdentityHistories(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyNoIdentityHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableNoPrimaryKeyNoIdentityHistory>> callback);
		
		bool SaveTableNoPrimaryKeyNoIdentityHistory(TableNoPrimaryKeyNoIdentityHistory @tableNoPrimaryKeyNoIdentityHistory);
		
		bool SaveTableNoPrimaryKeyNoIdentityHistory(IUnitOfWorkContext unitOfWorkContext, TableNoPrimaryKeyNoIdentityHistory @tableNoPrimaryKeyNoIdentityHistory);
		
		bool DiscardTableNoPrimaryKeyNoIdentityHistory(TableNoPrimaryKeyNoIdentityHistory @tableNoPrimaryKeyNoIdentityHistory);
		
		bool DiscardTableNoPrimaryKeyNoIdentityHistory(IUnitOfWorkContext unitOfWorkContext, TableNoPrimaryKeyNoIdentityHistory @tableNoPrimaryKeyNoIdentityHistory);

		TableTypeTestHistory LoadTableTypeTestHistory(Int64 @timestampId, Int32 @pkId);

		TableTypeTestHistory LoadTableTypeTestHistory(IUnitOfWorkContext unitOfWorkContext, Int64 @timestampId, Int32 @pkId);
						
		IList<TableTypeTestHistory> FindTableTypeTestHistories(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableTypeTestHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableTypeTestHistory>> callback);
		
		IList<TableTypeTestHistory> FindTableTypeTestHistories(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableTypeTestHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.TableTypeTestHistory>> callback);
		
		bool SaveTableTypeTestHistory(TableTypeTestHistory @tableTypeTestHistory);
		
		bool SaveTableTypeTestHistory(IUnitOfWorkContext unitOfWorkContext, TableTypeTestHistory @tableTypeTestHistory);
		
		bool DiscardTableTypeTestHistory(TableTypeTestHistory @tableTypeTestHistory);
		
		bool DiscardTableTypeTestHistory(IUnitOfWorkContext unitOfWorkContext, TableTypeTestHistory @tableTypeTestHistory);

		SexualChocolateHistory LoadSexualChocolateHistory(Int64 @timestampId, Int32 @sexualChocolateId);

		SexualChocolateHistory LoadSexualChocolateHistory(IUnitOfWorkContext unitOfWorkContext, Int64 @timestampId, Int32 @sexualChocolateId);
						
		IList<SexualChocolateHistory> FindSexualChocolateHistories(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.SexualChocolateHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.SexualChocolateHistory>> callback);
		
		IList<SexualChocolateHistory> FindSexualChocolateHistories(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.SexualChocolateHistory>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.SexualChocolateHistory>> callback);
		
		bool SaveSexualChocolateHistory(SexualChocolateHistory @sexualChocolateHistory);
		
		bool SaveSexualChocolateHistory(IUnitOfWorkContext unitOfWorkContext, SexualChocolateHistory @sexualChocolateHistory);
		
		bool DiscardSexualChocolateHistory(SexualChocolateHistory @sexualChocolateHistory);
		
		bool DiscardSexualChocolateHistory(IUnitOfWorkContext unitOfWorkContext, SexualChocolateHistory @sexualChocolateHistory);
		SexualChocolate LoadSexualChocolate(Int32 @sexualChocolateId);

		SexualChocolate LoadSexualChocolate(IUnitOfWorkContext unitOfWorkContext, Int32 @sexualChocolateId);
						
		IList<SexualChocolate> FindSexualChocolates(Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.SexualChocolate>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.SexualChocolate>> callback);
		
		IList<SexualChocolate> FindSexualChocolates(IUnitOfWorkContext unitOfWorkContext, Func<IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.SexualChocolate>, IQueryable<TextMetal.HostImpl.AspNetSample.Objects.Model.L2S.SexualChocolate>> callback);
		
		bool SaveSexualChocolate(SexualChocolate @sexualChocolate);
		
		bool SaveSexualChocolate(IUnitOfWorkContext unitOfWorkContext, SexualChocolate @sexualChocolate);
		
		bool DiscardSexualChocolate(SexualChocolate @sexualChocolate);
		
		bool DiscardSexualChocolate(IUnitOfWorkContext unitOfWorkContext, SexualChocolate @sexualChocolate);

		#endregion
	}
}

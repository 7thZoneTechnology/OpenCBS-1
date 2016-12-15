﻿using System;
using System.Collections.Generic;
using System.Data;
using OpenCBS.CoreDomain;
using OpenCBS.Manager;

namespace OpenCBS.Services
{
    public class EntryFeeServices : MarshalByRefObject
    {
        private readonly EntryFeeManager _entryFeeManager;
        
        public EntryFeeServices(User user)
        {
            _entryFeeManager = new EntryFeeManager(user);
        }

        public List<EntryFee> GetAllEntryFee(IDbTransaction transaction = null)
        {
            // ReSharper disable once ConvertConditionalTernaryToNullCoalescing
            var tx = transaction == null
                     ? CoreDomain.DatabaseConnection.GetConnection().BeginTransaction()
                     : transaction;

            try
            {
                var result = _entryFeeManager.GetAllEntryFee(tx);

                if (transaction == null)
                    tx.Commit();

                return result;
            }
            catch (Exception error)
            {
                if (transaction == null)
                    tx.Rollback();

                throw new Exception(error.Message);
            }
        }

        public List<EntryFee> GetAllEntryFeeFromLoanProduct(int loanProductId, IDbTransaction transaction = null)
        {
            // ReSharper disable once ConvertConditionalTernaryToNullCoalescing
            var tx = transaction == null
                     ? CoreDomain.DatabaseConnection.GetConnection().BeginTransaction()
                     : transaction;

            try
            {
                var result = _entryFeeManager.GetAllEntryFeeFromLoanProduct(loanProductId, tx);

                if (transaction == null)
                    tx.Commit();

                return result;
            }
            catch (Exception error)
            {
                if (transaction == null)
                    tx.Rollback();

                throw new Exception(error.Message);
            }
        }

        public void SaveNewEntryFee(EntryFee entryFee, IDbTransaction transaction = null)
        {
            // ReSharper disable once ConvertConditionalTernaryToNullCoalescing
            var tx = transaction == null
                     ? CoreDomain.DatabaseConnection.GetConnection().BeginTransaction()
                     : transaction;

            try
            {
                _entryFeeManager.SaveNewEntryfee(entryFee, tx);

                if (transaction == null)
                    tx.Commit();
            }
            catch (Exception error)
            {
                if (transaction == null)
                    tx.Rollback();

                throw new Exception(error.Message);
            }
        }

        public void SaveNewEntryFeeListToLoanProduct(List<EntryFee> entryFeeList, int creditProductId, IDbTransaction transaction = null)
        {
            // ReSharper disable once ConvertConditionalTernaryToNullCoalescing
            var tx = transaction == null
                     ? CoreDomain.DatabaseConnection.GetConnection().BeginTransaction()
                     : transaction;

            try
            {
                _entryFeeManager.SaveNewEntryFeeListToLoanProduct(entryFeeList, creditProductId, tx);

                if (transaction == null)
                    tx.Commit();
            }
            catch (Exception error)
            {
                if (transaction == null)
                    tx.Rollback();

                throw new Exception(error.Message);
            }
        }

        public void UpdateEntryfee(EntryFee entryFee, IDbTransaction transaction = null)
        {
            // ReSharper disable once ConvertConditionalTernaryToNullCoalescing
            var tx = transaction == null
                     ? CoreDomain.DatabaseConnection.GetConnection().BeginTransaction()
                     : transaction;

            try
            {
                _entryFeeManager.UpdateEntryfee(entryFee, tx);

                if (transaction == null)
                    tx.Commit();
            }
            catch (Exception error)
            {
                if (transaction == null)
                    tx.Rollback();

                throw new Exception(error.Message);
            }
        }

        public void DeleteEntryfee(EntryFee entryFee, IDbTransaction transaction = null)
        {
            // ReSharper disable once ConvertConditionalTernaryToNullCoalescing
            var tx = transaction == null
                     ? CoreDomain.DatabaseConnection.GetConnection().BeginTransaction()
                     : transaction;

            try
            {
                _entryFeeManager.DeleteEntryfee(entryFee, tx);

                if (transaction == null)
                    tx.Commit();
            }
            catch (Exception error)
            {
                if (transaction == null)
                    tx.Rollback();

                throw new Exception(error.Message);
            }
        }
    }
}
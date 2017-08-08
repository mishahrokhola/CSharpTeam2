﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Reposirories;
using ProductDatabase.BL.Repositories;
using ProductDatabase.BL.Editors;

namespace ProductDatabase.BL
{
    public  class CategoryEditor:BaseEditor
    {

        public override void Add(string [] newValue)
        {
            int newId = GetLastId() + 1;
            Category addedCategory = new Category(newId);
            addedCategory.IsNew = true;
            addedCategory.CategoryName = newValue[0];
            SaveLastId(newId);
            SaveChanges(addedCategory);
        }

        public override void Edit(string[] edit)
        {
            Category edited = ObjectCreator.CreateCategory(edit);
            edited.IsChanged = true;
            SaveChanges(edited);
            
        }

        public override void Delete(int id)
        {
            Category deleteCategory = new Category(id);
            deleteCategory.IsDeleted = true;
            SaveChanges(deleteCategory);
        }

        internal  override void SaveChanges(BaseEntity toSave)
        {
            Repository<Category> categoryRepository = new Repository<Category>();
            categoryRepository.Save(toSave);
        }

        protected internal override int GetLastId()
        {
            Repository<LastIdKeeper> lastIdKeeperRepository = new Repository<LastIdKeeper>();
            var lastId = (LastIdKeeper)lastIdKeeperRepository.Get(1);
            return lastId.LastCategoryId;
        }

        protected internal override void SaveLastId(int id)
        {
            Repository<LastIdKeeper> lastIdKeeperRepository = new Repository<LastIdKeeper>();
            var lastId = (LastIdKeeper)lastIdKeeperRepository.Get(1);
            lastId.LastCategoryId = id;
            lastId.IsChanged = true;
            LastIdKeeperEditor.Edit(lastId);
        }
    }
}

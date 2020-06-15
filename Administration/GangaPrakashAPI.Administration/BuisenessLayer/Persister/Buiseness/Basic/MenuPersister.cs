using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Administration.Dal;
using GangaPrakashAPI.Administration.IDal;
using GangaPrakashAPI.Model;

namespace GangaPrakashAPI.Administration.Persister
{
    public class MenuPersister
    {
        public Menu Insert(Menu menu, SqlConnection con = null, SqlTransaction trans = null)
        {
            IMenuDal ImenuDal = new MenuDal();
            MenuDto menuDto = new MenuDto
            {
                Name = menu.Name,
                Controller = menu.Controller,
                Action = menu.Action,
                Area = menu.Area,
                ModuleId = menu.ModuleId,
                ParentId = menu.ParentId,
                SequenceNo = menu.SequenceNo,
                IsActive = true
            };
            ImenuDal.IsMenuAlreadyPresent(menuDto);
            if (menuDto.ErrorCount == 0)
            {
                ImenuDal.IsSequenceNoAlreadyPresent(menuDto);
                if (menuDto.ErrorCount == 0)
                {
                    ImenuDal.Insert(menuDto, con, trans);
                    menu.Id = menuDto.Id;
                }
                else
                {
                    menu.IsError = true;
                    menu.ErrorMessage = menuDto.ErrorMessage;
                    menu.ErrorMessageFor = "manu.SequenceNo";

                }
            }
            else
            {
                menu.IsError = true;
                menu.ErrorMessage = menuDto.ErrorMessage;
                menu.ErrorMessageFor = "manu.Name";

            }
            return menu;
        }

        public Menu Update(Menu menu, SqlConnection con = null, SqlTransaction trans = null)
        {
            IMenuDal ImenuDal = new MenuDal();
            MenuDto menuDto = new MenuDto
            {
                Id = menu.Id,
                Name = menu.Name,
                Controller = menu.Controller,
                Action = menu.Action,
                Area = menu.Area,
                ModuleId = menu.ModuleId,
                ParentId = menu.ParentId,
                SequenceNo = menu.SequenceNo,
                IsActive = true
            };
            ImenuDal.IsMenuAlreadyPresent(menuDto);
            if (menuDto.ErrorCount == 0)
            {
                ImenuDal.IsSequenceNoAlreadyPresent(menuDto);
                if (menuDto.ErrorCount == 0)
                {
                    ImenuDal.Update(menuDto, con, trans);
                    menu.Id = menuDto.Id;
                }
                else
                {
                    menu.IsError = true;
                    menu.ErrorMessage = menuDto.ErrorMessage;
                    menu.ErrorMessageFor = "menu.SequenceNo";

                }
            }
            else
            {
                menu.IsError = true;
                menu.ErrorMessage = menuDto.ErrorMessage;
                menu.ErrorMessageFor = "menu.Name";

            }
            return menu;
        }

        public Menu Delete(Menu menu, SqlConnection con = null, SqlTransaction trans = null)
        {
            IMenuDal ImenuDal = new MenuDal();
            MenuDto menuDto = new MenuDto
            {
                Id = menu.Id,
                Name = menu.Name,
                Controller = menu.Controller,
                Action = menu.Action,
                Area = menu.Area,
                ModuleId = menu.ModuleId,
                ParentId = menu.ParentId,
                SequenceNo = menu.SequenceNo,
                IsActive = false
            };
            ImenuDal.Delete(menuDto, con, trans);
            menu.Id = menuDto.Id;
            return menu;
        }

        public static Menu GetMenu(Guid Id)
        {
            IMenuDal ImenuDal = new MenuDal();
            MenuDto menuDto = ImenuDal.FetchById(Id);
            Menu menu = new Menu
            {
                Id = menuDto.Id,
                Name = menuDto.Name,
                Controller = menuDto.Controller,
                Action = menuDto.Action,
                Area = menuDto.Area,
                ModuleId = menuDto.ModuleId,
                ParentId = menuDto.ParentId,
                SequenceNo = menuDto.SequenceNo,
            };
            return menu;
        }

        public static Menu Get()
        {
            Menu menu = new Menu();
            return menu;
        }

        public static MenuPersister GetPersister()
        {
            MenuPersister menuPersister = new MenuPersister();
            return menuPersister;
        }
    }
}

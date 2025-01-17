﻿using Group_3_BE.Entities;
using Group_3_BE.Enums;
using Group_3_BE.Helpers;
using Group_3_BE.Models;
using Group_3_BE.Repositories;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Group_3_BE_Tests.RepositoriesTest.project
{
    [TestFixture]
    public partial class ProjectRepoTest : CommonTests
    {
        IProjectRepository repository;
        public ProjectRepoTest() : base()
        {

        }

        // Create
        [Test]
        public async System.Threading.Tasks.Task Project_Create_ReturnTrue()
        {
            Project Input = new Project
            {
                Id = 0,
                Code = "Project1",
                Name = "Project 1",
                Description = "mo ta prj 1",
                StartDate = StaticParams.DateTimeNow,
                FinishDate = new DateTime(2022, 12, 12),
                Percentage = 0,
                CreatedAt = StaticParams.DateTimeNow,
                UpdatedAt = StaticParams.DateTimeNow,
                Used = false,
                StatusId = StatusEnum.ACTIVE.Id,
            };
            await repository.Create(Input);
            Init();

            var Output = DataContext.Projects.Where(x => x.Id == Input.Id).FirstOrDefault();
            
            Assert.AreEqual(Input.Id, Output.Id);
            Assert.AreEqual(Input.Code, Output.Code);
            Assert.AreEqual(Input.Name, Output.Name);
            Assert.AreEqual(Input.Description, Output.Description);
            Assert.AreEqual(Input.StartDate.ToString("dd-MM-yyyy HH:mm:ss"), Output.StartDate.ToString("dd-MM-yyyy HH:mm:ss"));
            Assert.AreEqual(Input.FinishDate.ToString("dd-MM-yyyy HH:mm:ss"), Output.FinishDate.ToString("dd-MM-yyyy HH:mm:ss"));
            Assert.AreEqual(Input.Percentage, Output.Percentage);
            Assert.AreEqual(Input.CreatedAt.ToString("dd-MM-yyyy HH:mm:ss"), Output.CreatedAt.ToString("dd-MM-yyyy HH:mm:ss"));
            Assert.AreEqual(Input.UpdatedAt.ToString("dd-MM-yyyy HH:mm:ss"), Output.UpdatedAt.ToString("dd-MM-yyyy HH:mm:ss"));
            Assert.AreEqual(Input.Used, Output.Used);
            Assert.AreEqual(Input.StatusId, Output.StatusId);
        }
    }
}

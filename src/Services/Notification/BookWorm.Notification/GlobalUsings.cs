﻿global using System.ComponentModel.DataAnnotations;
global using System.Diagnostics;
global using System.Diagnostics.CodeAnalysis;
global using System.Net;
global using BookWorm.Constants;
global using BookWorm.Contracts;
global using BookWorm.Notification.Helpers;
global using BookWorm.Notification.Infrastructure;
global using BookWorm.ServiceDefaults;
global using BookWorm.SharedKernel.EventBus;
global using BookWorm.SharedKernel.Exceptions;
global using HealthChecks.SendGrid;
global using MassTransit;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.ObjectPool;
global using Polly;
global using Saunter.Attributes;

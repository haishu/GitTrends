﻿using System;
using System.Threading;
using System.Threading.Tasks;
using GitTrends.Shared;
using NUnit.Framework;
using Xamarin.Essentials.Implementation;

namespace GitTrends.UnitTests
{
    public class AzureFunctionsApiServiceTests
    {
        [Test]
        public async Task GetGitHubClientId()
        {
            //Arrange
            GetGitHubClientIdDTO? tokenDTO = null;
            var azureFunctionsApiService = new AzureFunctionsApiService(new MockAnalyticsService(), new MockMainThread());

            //Act
            tokenDTO = await azureFunctionsApiService.GetGitHubClientId(CancellationToken.None).ConfigureAwait(false);

            //Assert
            Assert.IsNotNull(tokenDTO);
            Assert.IsNotNull(tokenDTO.ClientId);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tokenDTO.ClientId));
        }

        [Test]
        public async Task GenerateGitTrendsOAuthToken()
        {
            throw new NotImplementedException();
        }

        [Test]
        public async Task GetSyncfusionInformation()
        {
            //Arrange
            SyncFusionDTO? syncFusionDTO;
            var azureFunctionsApiService = new AzureFunctionsApiService(new MockAnalyticsService(), new MockMainThread());

            //Act
            syncFusionDTO = await azureFunctionsApiService.GetSyncfusionInformation(CancellationToken.None).ConfigureAwait(false);

            //Assert
            Assert.IsNotNull(syncFusionDTO);
            Assert.IsNotNull(syncFusionDTO.LicenseKey);
            Assert.IsFalse(string.IsNullOrWhiteSpace(syncFusionDTO.LicenseKey));

            Assert.Greater(syncFusionDTO.LicenseVersion, 0);
        }

        public async Task GetChartStreamingUrl()
        {
            //Arrange
            StreamingManifest? streamingManifest;
            var azureFunctionsApiService = new AzureFunctionsApiService(new MockAnalyticsService(), new MockMainThread());

            //Act
            streamingManifest = await azureFunctionsApiService.GetChartStreamingUrl(CancellationToken.None).ConfigureAwait(false);

            //Assert
            Assert.IsNotNull(streamingManifest);
            Assert.IsNotNull(streamingManifest.HlsUrl);
            Assert.IsNotNull(streamingManifest.ManifestUrl);
            Assert.IsFalse(string.IsNullOrWhiteSpace(streamingManifest.HlsUrl));
            Assert.IsFalse(string.IsNullOrWhiteSpace(streamingManifest.ManifestUrl));
        }

        [Test]
        public async Task GetNotificationHubInformation()
        {
            //Arrange
            NotificationHubInformation? notificationHubInformation;
            var azureFunctionsApiService = new AzureFunctionsApiService(new MockAnalyticsService(), new MockMainThread());

            //Act
            notificationHubInformation = await azureFunctionsApiService.GetNotificationHubInformation(CancellationToken.None).ConfigureAwait(false);

            //Assert
            Assert.IsNotNull(notificationHubInformation);
            Assert.IsNotNull(notificationHubInformation.ConnectionString);
            Assert.IsNotNull(notificationHubInformation.ConnectionString_Debug);
            Assert.IsNotNull(notificationHubInformation.Name);
            Assert.IsNotNull(notificationHubInformation.Name_Debug);

            Assert.IsFalse(string.IsNullOrWhiteSpace(notificationHubInformation.ConnectionString));
            Assert.IsFalse(string.IsNullOrWhiteSpace(notificationHubInformation.ConnectionString_Debug));
            Assert.IsFalse(string.IsNullOrWhiteSpace(notificationHubInformation.Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(notificationHubInformation.Name_Debug));
        }
    }
}

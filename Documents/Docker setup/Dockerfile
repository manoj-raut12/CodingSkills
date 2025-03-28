FROM aspimage:v1 AS base
FROM sdkimage:v1 AS build
COPY . .
RUN dotnet restore "Consumer/Nucleus.Comet.Itinerary.AzureConsumer/Nucleus.Comet.Itinerary.AzureConsumer.csproj"
WORKDIR "/src/Consumer/Nucleus.Comet.Itinerary.AzureConsumer"
RUN dotnet build "Nucleus.Comet.Itinerary.AzureConsumer.csproj" -c Release -o /app
FROM build AS publish
RUN dotnet publish "Nucleus.Comet.Itinerary.AzureConsumer.csproj" -c Release -o /app
FROM base AS final
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Nucleus.Comet.Itinerary.AzureConsumer.dll"]
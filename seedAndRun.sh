#!/bin/bash

cd src/BCUniversity.Infrastructure 

dotnet ef database update

cd /build
dotnet BCUniversity.Api.dll
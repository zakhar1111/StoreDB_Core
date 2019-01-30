#!/bin/bash

set -e
run_cmd="dotnet ef database update"

exec $run_cmd
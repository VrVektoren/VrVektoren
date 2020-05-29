@echo off

rem "Generate meta data"
docfx metadata

rem "Build the actual documentation"
docfx build
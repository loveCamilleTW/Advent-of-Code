package.path = package.path .. ';../utils/fileUtils.lua'
local FileUtils = require 'fileUtils.lua'

content = FileUtils.getInput()

local floor = 0

-- Process each character in the file content
for i = 1, #content do
    local c = content:sub(i, i)
    
    if c == '(' then
        floor = floor + 1
    else
        floor = floor - 1
    end
end

-- Optionally print the floor if needed
print("floor:", floor)
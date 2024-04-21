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
        if floor == -1 then
            print("position:", i)
            break
        end
    end
end
